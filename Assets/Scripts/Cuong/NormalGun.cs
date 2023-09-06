using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NormalGun : MonoBehaviour
{
    // Start is called before the first frame update
    public int Atk = 2;
    public int Range = 10;
    public int Gold = 50;
    public int Level = 1;
    public float Reload = 2;
    public int upgradeGold = 40;
    public int sellGold = 20;
    public AudioSource aus;

    public GameObject bullet;
    public GameObject Normal_gun; 
    public UnityEngine.Transform Spot;
	public float counter = 0;
    public int z = 0;
	public GameObject CurrentEnemy  ;

	void Start()
    {
        //Atk = 5;
        //Range = 10;
        //Reload = 2;
        //Gold = 30; 
        //Level= 1;
        //upgradeGold = 30;
        //sellGold = 20;
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
                    GameObject obj = Instantiate<GameObject>(bullet, Spot.position, Normal_gun.transform.rotation);
                    aus.Play();
                    if (CurrentEnemy == null)
                    {
                        Destroy(obj.GetComponent<NormalBullet>());
                        

                    }
                    obj.GetComponent<NormalBullet>().gun(Atk, CurrentEnemy.gameObject);
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
        return true;
    }
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position,Range); 
	}
    public void UpdateNormal()
    {
        Level++;
        Atk = Atk + 1;
        if (Level % 5 == 0)
        {
            Range = Range + 1;
            Reload = (float)(Reload * 0.9);
        }
        upgradeGold = upgradeGold + 30;
        sellGold = sellGold + 10;
    }

    public void isNew()
    {
        Atk = 2;
        Range = 10;
        Gold = 50;
        Level = 1;
        Reload = 2;
        upgradeGold = 70;
        sellGold = 20;
    }
}

