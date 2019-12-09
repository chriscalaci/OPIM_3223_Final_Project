using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public GameObject effectObject;
    public AudioClip shootingSound;
    private AudioSource audioSource;

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
    }
}
