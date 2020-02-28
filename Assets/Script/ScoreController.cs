using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public GameObject popUp;
    public GameObject ball;
    public Text winLoseCondition;
    public Text playerScoreText;
    private string playerScore;
    public Text enemyScoreText;
    private string enemyScore;
    public float maxScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerScore = PlayerAttribute.score.ToString();
        enemyScore = EnemyAttribute.score.ToString();

        playerScoreText.text = playerScore;
        enemyScoreText.text = enemyScore;

        if(PlayerAttribute.score >= maxScore)
        {
            Time.timeScale = 0;
            winLoseCondition.text =  "You Win!";
            popUp.SetActive(true);
            ball.SetActive(false);
            
        }
        if(EnemyAttribute.score >= maxScore)
        {
            Time.timeScale = 0;
            winLoseCondition.text =  "You Lose!";
            popUp.SetActive(true);
            ball.SetActive(false);
        }
    }
}
