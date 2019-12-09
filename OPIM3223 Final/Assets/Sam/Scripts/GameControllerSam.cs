using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerSam : MonoBehaviour
{
    public AudioClip cheers;
    private AudioSource audioSource;
    public Fireworks fireworks;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        player.onPlayerDeath += onPlayerDeath;
        player.onClassReached += onClassReached;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }

    void onClassReached(Player player)
    {
        audioSource.PlayOneShot(cheers);
        fireworks.explode();
        Invoke("win", 3);
    }

    void onPlayerDeath(Player player)
    {
        Destroy(player.gameObject);

        Invoke("restartGame", 3);
    }

    void win()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }

        SceneManager.LoadScene("AliScene");
    }

    void restartGame()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }

        SceneManager.LoadScene("MenuScene");
    }
}
