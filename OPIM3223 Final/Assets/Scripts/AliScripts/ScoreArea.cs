using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreArea : MonoBehaviour
{
    public GameObject effectObject;
    public AudioClip shootingSound;
    private AudioSource audioSource;

    public event Action<ScoreArea> onGameWin;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        effectObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>() != null)
        {
            
            effectObject.SetActive(true);
        }

        audioSource.PlayOneShot(shootingSound);

        if (onGameWin != null)
        {
            onGameWin(this);
        }
    }
}
