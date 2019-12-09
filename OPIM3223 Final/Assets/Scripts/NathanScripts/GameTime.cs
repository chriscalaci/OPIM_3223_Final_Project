using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
public class GameTime : MonoBehaviour
{
    public float TimeLeft=30;
    public int Score = 0;
    private AudioSource audioSource;
    public AudioClip Asound;
    public event Action<GameTime> OnGameWin;
    public Text ScoreText;
    public Text WinText;
    public Text TimeText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ScoreText.text = "Score:" + Score;
        WinText.text = "Results:";
        TimeText.text = "Time Remaining" + TimeLeft.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeLeft -= Time.deltaTime;
        TimeText.text = TimeLeft.ToString();
        if (TimeLeft < 0)
        {
           
            WinText.text = "See you next semester!";
            Invoke("MoveFloor", 2.5f);
            this.gameObject.SetActive(false);
            Invoke("restartGame",5f);

        }
     

    }

    void MoveFloor()
    {
        var x = GameObject.FindWithTag("Floor");
        x.SetActive(false);
    }
    void restartGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("F"))
        {
            TimeLeft -= 1f;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("A"))
        {
            Score += 5;
            audioSource.PlayOneShot(Asound);
            other.gameObject.SetActive(false);
            ScoreText.text = "Score:" + Score.ToString();


        }
        if (other.gameObject.CompareTag("B"))
        {
            Score += 3;
            other.gameObject.SetActive(false);
            ScoreText.text = "Score:" + Score.ToString();
        }
        if (other.gameObject.CompareTag("C"))
        {
            Score += 1;
            other.gameObject.SetActive(false);
            ScoreText.text = "Score:" + Score;

        }
        if (other.gameObject.CompareTag("D"))
        {
            Score -= 1;
            other.gameObject.SetActive(false);
            ScoreText.text = "Score:" + Score.ToString();
        }
        if (other.gameObject.CompareTag("Graduation"))
        {
            ScoreText.text = "Score:" + Score.ToString();

            if (Score>=10)
            {
              
                other.gameObject.SetActive(false);
                OnGameWin(this);
            }
          



        }
        if (other.gameObject.CompareTag("Beer"))
        {
            TimeLeft -= 1;
            Score -= 1;
            ScoreText.text = "Score:" + Score.ToString();
            other.gameObject.SetActive(false);
        }
      

    

    }
    public void GameWin()
    {
        TimeLeft += 60f;
        this.gameObject.SetActive(false);

    }
    


}

