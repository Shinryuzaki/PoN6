using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private SpriteRenderer ballRender;
    private SpriteRenderer playerRender;
    private SpriteRenderer enemyRender;
    private int skill = 0;
    private float randSkill;
    private float skillCoolDownTime;
    // private Rigidbody2D ballRb;

    // Start is called before the first frame update
    void Start()
    {
        ballRender = GameObject.Find("Ball").GetComponent<SpriteRenderer>();
        playerRender = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        enemyRender = GameObject.Find("Enemy").GetComponent<SpriteRenderer>();
        BallAttribute.rigidBody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        randSkill = Random.Range(0, 1f);
        if(BallAttribute.rigidBody.transform.position == Vector3.zero)
        {
            if (randSkill >= 0.5)
            {
                if(skillCoolDownTime <= 2f)
                {
                    CastSkillFireBall();
                    skillCoolDownTime += Time.deltaTime;
                }
                else
                {
                    DiscastSklillFireBall();
                    skillCoolDownTime = 0f;
                }
            }
            else
            {
                if(skillCoolDownTime >= 2f)
                {
                    CastEnlarge();
                    skillCoolDownTime += Time.deltaTime;
                }
                else
                {
                    DiscastSklillEnlarge();
                     skillCoolDownTime = 0f;
                } 
                
            }
        }
    }

    private void CastSkillFireBall()
    {
        Color fireryBallColor = Color.red;
        ballRender.material.color = fireryBallColor;
        BallAttribute.fireBall = true;
    }
    
    private void DiscastSklillFireBall()
    {
        Color fireryBallColor = Color.white;
        ballRender.material.color = fireryBallColor;
        BallAttribute.fireBall = false;
    }

    private void DiscastSklillEnlarge()
    {
        if(PlayerAttribute.enlarge == true)
        {
            PlayerAttribute.enlarge = false;
            Color enlargeColor = Color.white;
            playerRender.material.color = enlargeColor;
            playerRender.transform.localScale = new Vector3 (10f, 100f, 0f);
        }
        else if(EnemyAttribute.enlarge == true)
        {
            EnemyAttribute.enlarge = false;
            Color enlargeColor = Color.yellow;
            enemyRender.material.color = enlargeColor;
            enemyRender.transform.localScale = new Vector3 (10f, 100f, 0f);
        }
    }

    private void CastEnlarge()
    {
        float randWho = Random.Range(0, 1f);
        if (randWho >= 0.5f)
            {
                Color enlargeColor = Color.blue;
                playerRender.material.color = enlargeColor;
                playerRender.transform.localScale = new Vector3 (10f, 380f, 0f);
                PlayerAttribute.enlarge = true;
            }
            else
            {
                Color enlargeColor = Color.yellow;
                enemyRender.material.color = enlargeColor;
                enemyRender.transform.localScale = new Vector3 (10f, 380f, 0f);
                EnemyAttribute.enlarge = true;
            }
        
    }
}
