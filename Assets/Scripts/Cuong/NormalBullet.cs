using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed; 
	private Vector3 movepoint ;
	private GameObject target ;

	private int atk; 
    void Start()
    {
        speed = 10;
    }
	public void gun(int atk , GameObject target)
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
			switch (collision.name)
			{
				case ("Alien(Clone)"):
				{
					collision.GetComponent<AlienEnemy>().DealDamage(atk);
                        Destroy(gameObject);
                        break;
				}
                case ("Lizard(Clone)"):
                    {
                        collision.GetComponent<LizardEnemy>().DealDamage(atk);
                        Destroy(gameObject);
                        break;
                    }
                case ("Robot(Clone)"):
                    {
                        collision.GetComponent<RobotEnemy>().DealDamage(atk);
                        Destroy(gameObject);
                        break;
                    }
                case ("Boss(Clone)"):
                    {
                        collision.GetComponent<HealthBoss>().DealDamage(atk);
                        Destroy(gameObject);
                        break;
                    }
            }
            
		}
	}

}
