using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LizardEnemy : MonoBehaviour
{
    public float startSpeed = 20f;

    [HideInInspector]
    public float speed;
    float time = 0;

    public float startHealth = 15;
    private float health;
    private int worth = 15;

    public float MoveSpeed;
    private WalkPoint walkPoint;
    private int walkPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        speed = startSpeed;
        walkPoint = GameObject.FindGameObjectWithTag("walkpoint").GetComponent<WalkPoint>();
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
            transform.localScale = new Vector3((float)1.5, (float)1.5, 0);
        }
        else
        {
            transform.localScale = new Vector3((float)-1.5, (float)1.5, 0);
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
