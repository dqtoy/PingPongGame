using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    private Rigidbody2D ball;
    
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        GoBall();
    }
    private void Update()
    {
        Vector2 velocity = ball.velocity;
        if(-9<velocity.x && velocity.x<9 && velocity.x != 0)
        {
            if(velocity.x > 9)
            {
                velocity.x = 10;
            }
            else
            {
                velocity.x = -10 ;
            }

            ball.velocity = velocity;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Vector2 velocity = ball.velocity;
            velocity.y = collision.rigidbody.velocity.y/2 + velocity.y/2f;
            ball.velocity = velocity;
        }
        if(collision.gameObject.name =="rightWall" || collision.gameObject.name == "leftWall")
        {
            GameManager.Instance.ChangeScore(collision.gameObject.name);
        }
    }
    
    public void Reset()
    {
        
        transform.position = Vector3.zero;
        GoBall();
    }
    
    void GoBall()
    {
        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            ball.AddForce(new Vector2(100, 0));
        }
        else
        {
            ball.AddForce(new Vector2(-100, 0));
        }
    }
}
