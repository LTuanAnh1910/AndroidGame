using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class AlienEnemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    float time = 0;

    public float startHealth = 10;
    public float health;

    private int worth = 10;
    private bool isLine = true;
    public float MoveSpeed;
    private WalkPoint walkPoint;
    private int walkPointIndex;

    // Start is called before the first frame update
    void Start()
    {

        health = startHealth;
        speed = startSpeed;
        walkPoint = GameObject.Find("WalkPointLine1").GetComponent<WalkPoint>();
        Debug.Log(walkPoint.transform.position.x + ", " + walkPoint.transform.position.y + "WalkPointLine1");
        //walkPoint = GameObject.Find("WalkPointLine2").GetComponent<WalkPoint>();
        //Debug.Log(walkPoint.transform.position.x + ", " + walkPoint.transform.position.y + "WalkPointLine2");
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, walkPoint.walkpoints[walkPointIndex].position, MoveSpeed * Time.deltaTime);

        if (transform.position.x < walkPoint.walkpoints[walkPointIndex].position.x)
        {
            transform.localScale = new Vector3((float)0.3, (float)0.3, 0);
        }
        else
        {
            transform.localScale = new Vector3((float)-0.3, (float)0.3, 0);
        }



        if (Vector2.Distance(transform.position, walkPoint.walkpoints[walkPointIndex].position) < 0.1f)
        {
            if (walkPointIndex < walkPoint.walkpoints.Length - 1)
            {
                walkPointIndex++;
            }
            else
            {
                Player.Heart--;
                Destroy(gameObject);
            }
        }
    }

    public void DealDamage(float damage)
    {
        startHealth = startHealth - damage;
        if (startHealth <= 0)
        {
            startHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Player.Gold += worth;
            Destroy(gameObject);
        }
        if (startHealth == 0)
        {
            //audio.Play();
            time = 2;
        }
    }

    public void MinusHeart()
    {
        Player.Heart--;
        Destroy(gameObject);
    }
}
