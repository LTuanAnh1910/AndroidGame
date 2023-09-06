using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGun : MonoBehaviour
{
    // Start is called before the first frame update

    public int Atk = 5;
    public int Range = 10;
    public int Gold = 100;
    public int Level = 1;
    public float Reload = 2;
    public int upgradeGold = 100;
    public int sellGold = 30;
    public AudioSource aus;

    public GameObject Explosion_bullet;
	public GameObject Explosion_gun;
	public UnityEngine.Transform Spot;
	public float counter = 0;
	public GameObject CurrentEnemy;


	void Start()
	{
		//Atk = 5;
		//Range = 10;
		//Reload = 2;
		//Gold = 30;
		//Level = 1;
  //      upgradeGold = 50;
  //      sellGold = 30;
    }

	// Update is called once per frame
	void Update()
	{
		counter = counter + Time.deltaTime;
		Rotate();
	}
	private void Rotate()
	{
		if (CurrentEnemy == null)
		{
			Collider2D[] hit = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), Range);
			for (int i = 0; i < hit.Length; i++)
			{
				if (hit[i].tag == "Enemy" && hit.Length >= 1)
				{
					CurrentEnemy = hit[i].gameObject;
				}
			}
		}
		else
		{
            if (Vector3.Distance(transform.position, CurrentEnemy.transform.position) <= Range)
            {
                Vector2 lookDir = CurrentEnemy.transform.position - transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                if (counter > Reload)
                {
                    GameObject obj = Instantiate<GameObject>(Explosion_bullet, Spot.position, Explosion_gun.transform.rotation);
                    aus.Play();
                    obj.GetComponent<ExplosionBullet>().gun(Atk, CurrentEnemy.gameObject);
                    counter = 0;
                }
            }
            else
            {
                CurrentEnemy = null;
            }
        }
		
	}
    public bool isNormal()
    {
        return false;
    }
    private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawSphere(transform.position, Range);
	}

    public void UpdateExplo()
    {
        Level++;
        Atk = Atk + 2;
        if (Level % 5 == 0)
        {
            Range = Range + 1;
            Reload = (float)(Reload * 0.9);
        }
        upgradeGold = upgradeGold + 50;
        sellGold = sellGold + 30;
    }
    public void isNew()
    {
        Atk = 5;
        Range = 10;
        Gold = 100;
        Level = 1;
        Reload = 2;
        upgradeGold = 100;
        sellGold = 30;
    }
}
