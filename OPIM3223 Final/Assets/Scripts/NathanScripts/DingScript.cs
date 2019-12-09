using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingScript : MonoBehaviour
{
    public AudioSource audiosource;
    private AudioClip audiClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audiosource.PlayOneShot(audiClip);

        }
    }
}
