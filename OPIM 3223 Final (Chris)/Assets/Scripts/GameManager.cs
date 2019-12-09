using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public int currentMoney;
    private int currentHealth;
    public Text moneyText;
    public Text healthText;
    public int moneyToCollect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        moneyText.text = "Money: $ " + currentMoney;
        
        if(currentMoney >= moneyToCollect)
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
    

    }

    
