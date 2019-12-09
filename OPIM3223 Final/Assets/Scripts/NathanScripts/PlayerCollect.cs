using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollect : MonoBehaviour
{

    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        if(Score==10)
        {
            SceneManager.LoadScene("MenuScene");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("A"))
        {
            Score += 5;
            other.gameObject.SetActive(false);

        }
        if(other.gameObject.CompareTag("B"))
        {
            Score += 3;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("C"))
        {
            Score += 1;
            other.gameObject.SetActive(false);

        }
        if(other.gameObject.CompareTag("D"))
        {
            Score -= 1;
            other.gameObject.SetActive(false);
        }
    }

}
