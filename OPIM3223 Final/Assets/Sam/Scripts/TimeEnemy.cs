using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEnemy : MonoBehaviour
{

    public float moveSpeed = 5000;

    public int damage = 1;
    public Transform targetTransform;
    


    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    public void Attack(Player player)
    {
        player.health -= this.damage;
        
        Destroy(this.gameObject);
    }

    
    
}
