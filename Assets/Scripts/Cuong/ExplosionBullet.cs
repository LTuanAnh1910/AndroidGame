using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : MonoBehaviour
{

	private int range;
	private int speed;
	private Vector3 movepoint;
	private GameObject target;
	private int atk;


	void Start()
	{
		range = 5;
		speed = 10;
	}
	public void gun(int atk, GameObject target)
	{
		this.target = target;
		this.atk = atk;
	}
	// Update is called once per frame
	void Update()
	{
		if (target != null)
		{
			movepoint = target.transform.position;
			transform.position = Vector2.MoveTowards(transform.position, movepoint, speed * Time.deltaTime);
		}
		else
		{
			Destroy(gameObject);

		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		{
			DestroyEnemy();
			Destroy(gameObject);
		}
	}
	private void DestroyEnemy()
	{
        Collider2D[] Enemy = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), range);
		for (int i = 0; i < Enemy.Length; i++){
            if (Enemy[i].tag == "Enemy")
            {
                switch (Enemy[i].name)
                {
                    case ("Alien(Clone)"):
                        {
                            Enemy[i].GetComponent<AlienEnemy>().DealDamage(atk);
                            Destroy(gameObject);
                            break;
                        }
                    case ("Lizard(Clone)"):
                        {
                            Enemy[i].GetComponent<LizardEnemy>().DealDamage(atk);
                            Destroy(gameObject);
                            break;
                        }
                    case ("Robot(Clone)"):
                        {
                            Enemy[i].GetComponent<RobotEnemy>().DealDamage(atk);
                            Destroy(gameObject);
                            break;
                        }
                    case ("Boss(Clone)"):
                        {
                            Enemy[i].GetComponent<HealthBoss>().DealDamage(atk);
                            Destroy(gameObject);
                            break;
                        }
                }

            }

        }

    }

}