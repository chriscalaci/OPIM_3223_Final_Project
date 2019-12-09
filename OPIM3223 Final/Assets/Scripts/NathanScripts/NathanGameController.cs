using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NathanGameController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<GameTime>();
        player.OnGameWin += OnGameWin;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGameWin(GameTime gameTime)
    {

        gameTime.GameWin();
        Invoke("restartGame", 3);
        gameTime.WinText.text = "You Graduated!!!";

    }

    void restartGame()
    {
        //SceneManager.LoadScene("NextScene");
    }

}

