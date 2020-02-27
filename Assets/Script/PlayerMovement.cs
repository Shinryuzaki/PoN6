﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAttribute{
    public static int score = 0;
    public static float movementSpeed = 10f;
    public static Rigidbody2D rigidBody;
    public static bool enlarge = false;
}

public class PlayerMovement : MonoBehaviour
{
    private float move;
    private float yUpBound = 5.5f;
    private float yBottomBound = -4.2f;

    private Vector2 originalPos;
    private ContactPoint2D lastContactPoint;
    private Vector2 trajectoryOrigin;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttribute.rigidBody = GetComponent<Rigidbody2D>();
        originalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement(){
        
        move = Input.GetAxis("Vertical1") * PlayerAttribute.movementSpeed * Time.deltaTime;
        float position = transform.position.y + move;
        if(PlayerAttribute.enlarge == true)
        {
            this.transform.position = originalPos;
            
            if (position > 2f)
            {
                move = 0;
            }
            if (position < -0.5f)
            {
                move = 0;
            }
        }
        else
        {  
            if (position > yUpBound)
            {
                move = 0;
            }
            if (position < yBottomBound)
            {
                move = 0;
            }
        }
        transform.Translate(0, move, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "Ball"){
            lastContactPoint = collision.GetContact(0);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
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
