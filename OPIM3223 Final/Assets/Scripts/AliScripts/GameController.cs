using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AliPlayer player;
    public float resetTimer = 5f;


    // Start is called before the first frame update
    void Start()
    {
        var score = GameObject.FindGameObjectWithTag("ScoreArea").GetComponent<ScoreArea>();
        score.onGameWin += onGameWin;
    }

    // Update is called once per frame
    void Update()
    {

       if (player.holdingBall == false)
        {
            resetTimer -= Time.deltaTime;

            //Lose scenario
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }

    void onGameWin (ScoreArea score)
    {
        SceneManager.LoadScene("MenuScene");
    }

    
}
