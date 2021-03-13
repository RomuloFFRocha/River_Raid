using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    bool facingRight;
    public bool enemy;

    public Transform[] moveSpots;
    private int nextSpot;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);
      

        if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f)
        {
            
            if (waitTime <= 0)
            {
                nextSpot++;
                waitTime = startWaitTime;
                if (enemy) Enemy();
                else Flip();

                if (nextSpot >= moveSpots.Length)
                {
                    nextSpot = 0;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }

    private void Flip()
    {

        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = !facingRight;
        }

    }

    private void Enemy()
    {

        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = !facingRight;
        }
        else if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = !facingRight;
        }

    }

}
