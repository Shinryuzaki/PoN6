using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAttribute{
    public static int score = 0;
    public static float movementSpeed = 10f;
    public static Rigidbody2D rigidBody;
    public static bool enlarge = false;
}

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float yUpBound = 5.5f;
    private float yBottomBound = -4f;
    private ContactPoint2D lastContactPoint;
    private Vector2 trajectoryOrigin;
    public GameObject ball;

    private Vector2 originalPos;
    public float ballDistance;
     void Start()
    {
        EnemyAttribute.rigidBody = GetComponent<Rigidbody2D>();
        originalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 ballPos = new Vector2(this.transform.position.x, ball.transform.position.y);
        Vector2 curentPos = this.transform.position;

        if(Vector2.Distance(curentPos, ballPos) > ballDistance)
        {
            if (ball.transform.position.y > yUpBound && EnemyAttribute.enlarge == false || ball.transform.position.y < yBottomBound && EnemyAttribute.enlarge == false)
            {
                curentPos = new Vector2(this.transform.position.x, this.transform.position.y);
            }else
            {
                this.transform.position = originalPos; 
            }
            transform.position = Vector2.MoveTowards(curentPos, ballPos, EnemyAttribute.movementSpeed * Time.deltaTime);
        }
             
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "Ball"){
            lastContactPoint = collision.GetContact(0);
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public ContactPoint2D LastContactPoint()
    {
        return lastContactPoint;
    }

    public Vector2 TrajectoryOrigin()
    {
        return trajectoryOrigin;
    }
}
