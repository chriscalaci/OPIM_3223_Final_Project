using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public Animator fireworkAnimator;
    public GameObject fireworksPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode()
    {
        fireworkAnimator.SetBool("fireworksExplode", true);
        if (fireworksPrefab)
        {
            GameObject fireworkExplosion = (GameObject)Instantiate(fireworksPrefab, new Vector3(32f, 30f, 44.8f), fireworksPrefab.transform.rotation);
            Destroy(fireworkExplosion, fireworkExplosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
        }
    }
}
