using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BossEnemy : MonoBehaviour
{
    private float MoveSpeed;
    private WalkPoint walkPoint;

    private int walkPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        //walkPoint = GameObject.FindGameObjectWithTag("walkpoint").GetComponent<WalkPoint>();
        walkPoint = GetComponent<WalkPoint>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, walkPoint.walkpoints[walkPointIndex].position, MoveSpeed * Time.deltaTime);

        if (transform.position.x < walkPoint.walkpoints[walkPointIndex].position.x)
        {
            transform.localScale = new Vector3((float)0.6, (float)0.6, 0);
        }
        else
        {
            transform.localScale = new Vector3((float)-0.6, (float)0.6, 0);
        }


        if (Vector2.Distance(transform.position, walkPoint.walkpoints[walkPointIndex].position) < 0.1f)
        {
            if (walkPointIndex < walkPoint.walkpoints.Length - 1)
            {
                walkPointIndex++;
            }
            else
            {

                MinusHeart();
                MoveSpeed++;
                return;
            }
        }
    }

    public void MinusHeart()
    {
        Player.Heart--;
        Destroy(gameObject);
    }
}
