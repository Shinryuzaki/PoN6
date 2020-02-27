using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallAttribute{
    public static Rigidbody2D rigidBody;
    public static Collider2D ballCol;
    public static Vector2 trajectoryOrigin;
    public static bool fireBall = false;
}
public class BallMovement : MonoBehaviour
{
        private float xForce = 10f;
        private float yForce = 10f;
    private float ballRand;
    // Start is called before the first frame update
    void Start()
    {
        BallAttribute.rigidBody = GetComponent<Rigidbody2D>();
        BallPush();
    }

    // Update is called once per frame
    void Update()
    {
        ResetBallPoss();
    }

    public void BallPush()
    {
        float yRandomInitialForce = Random.Range(-yForce, yForce);
        ballRand = Random.Range(0f, 2f);
        if (ballRand > 1)
        {
            BallAttribute.rigidBody.velocity = new Vector2(-xForce, yRandomInitialForce);
        }
        else
        {
            BallAttribute.rigidBody.velocity = new Vector2(xForce, yRandomInitialForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float playerDistance = this.transform.position.y - GameObject.Find("Player").transform.position.y;
        float enemyDistance = this.transform.position.y - GameObject.Find("Enemy").transform.position.y;
        if (collision.gameObject.name == "Player")
        {
            BallAttribute.rigidBody.velocity = new Vector2(xForce, playerDistance);   
        }
        if (collision.gameObject.name == "Enemy")
        {
            BallAttribute.rigidBody.velocity = new Vector2(-xForce, enemyDistance);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        float playerDistance = this.transform.position.y - GameObject.Find("Player").transform.position.y;
        float enemyDistance = this.transform.position.y - GameObject.Find("Enemy").transform.position.y;
        if (other.gameObject.name == "Player")
        {
            BallAttribute.rigidBody.velocity = new Vector2(xForce, playerDistance);   
        }
        if (other.gameObject.name == "Enemy")
        {
            BallAttribute.rigidBody.velocity = new Vector2(-xForce, enemyDistance);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.gameObject.name == "EnemyTrigger")
        {
            PlayerAttribute.score+=1;
             if(BallAttribute.fireBall == true)
            {
                PlayerAttribute.score+=5;
            }
        }
        if(other.gameObject.name == "PlayerTrigger")
        {
            EnemyAttribute.score+=1;
            if(BallAttribute.fireBall == true)
            {
                EnemyAttribute.score+=5;
            }
        }
    }
    private void ResetBallPoss()
    {
        if (Mathf.Abs(this.transform.position.x) > 13.5f)
        {   
            this.transform.position = Vector3.zero;
            BallPush();
        }
    }

}
