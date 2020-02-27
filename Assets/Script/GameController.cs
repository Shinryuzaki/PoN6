using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text debugText;
    private Text onOffText;
    //For debugging Purpose.
    public PlayerMovement player;
    public EnemyMovement enemy;
    public Rigidbody2D ballRb;
    public Collider2D ballCol;
    private Vector2 ballVelocity;
    private Vector2 ballMomentum;
    private float ballMass;
    private float ballSpeed;
    private float ballFriction;
    private float impulsePlayerX;
    private float impulsePlayerY;
    private float impulseEnemyX;
    private float impulseEnemyY;
    private string debug;
    private int onOfSwitch;
    // Start is called before the first frame update
    void Start()
    {
        onOffText = GameObject.Find("ToggleButton").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        IsDebug();
    }
    public void IsDebug()
    {
        if (onOfSwitch == 1)
        {
            onOffText.text = "Debug: ON";
            ballMass = ballRb.mass;
            ballVelocity = ballRb.velocity;
            ballSpeed = ballRb.velocity.magnitude;
            ballMomentum = ballMass * ballVelocity;
            ballFriction = ballCol.friction;
            impulsePlayerX = player.LastContactPoint().normalImpulse;
            impulsePlayerY = player.LastContactPoint().tangentImpulse;
            impulseEnemyX = enemy.LastContactPoint().normalImpulse;
            impulseEnemyY = enemy.LastContactPoint().tangentImpulse;

            debug =
                    "Ball mass = " + ballMass + "\t\t" +
                    "Ball velocity = " + ballVelocity + "\t\t" +
                    "Ball speed = " + ballSpeed + "\t\t" +
                    "Ball momentum = " + ballMomentum + "\n\n" +
                    "Ball friction = " + ballFriction + "\t\t" +
                    "Last impulse from player 1 = (" + impulsePlayerX + ", " + impulsePlayerY + ")\t\t" +
                    "Last impulse from player 2 = (" + impulseEnemyX + ", " + impulseEnemyY + ")\t\t";
            debugText.text = debug;
        }
        else if(onOfSwitch == 0)
        {
            onOffText.text = "Debug: OFF";
            debugText.text = "Debug is Deactive";
        }
    }
    public void ToggleDebug()
    {
        
        if (onOfSwitch == 1)
        {
            onOfSwitch = 0;
        }
        else 
        {
            onOfSwitch = 1;
        }
    }
}
