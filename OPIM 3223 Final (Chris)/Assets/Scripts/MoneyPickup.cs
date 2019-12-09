using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{

    public int value;

    public GameObject pickupEffect;
    // Start is called before the first frame update

    public AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddMoney(value);
            

            Instantiate(pickupEffect, transform.position, transform.rotation);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play(0);
            Destroy(gameObject);
        }
    }


}
