using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    public float acceleration = 700;
    public float maxSpeed = 6000;
    public int health = 3;
    private Rigidbody rigidBody;
    private KeyCode[] inputKeys;
    private Vector3[] keyDirections;

    public event Action<Player> onPlayerDeath;
    public event Action<Player> onClassReached;

    // Start is called before the first frame update
    void Start()
    {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        keyDirections = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            var currentKey = inputKeys[i];

            if (Input.GetKey(currentKey))
            {
                Vector3 move = keyDirections[i] * acceleration * Time.deltaTime;
                movePlayer(move);
            }
            /*
            if (Input.GetKeyDown(KeyCode.W))
                transform.forward = new Vector3(1f, 0f, 0f);
            else if (Input.GetKeyDown(KeyCode.S))
                transform.forward = new Vector3(-1f, 0f, 0f);
            else if (Input.GetKeyDown(KeyCode.A))
                transform.forward = new Vector3(0f, 0f, 1f);
            else if (Input.GetKeyDown(KeyCode.D))
                transform.forward = new Vector3(0f, 0f, -1f);
                */

            Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Vertical"), 0,  - 1 * Input.GetAxisRaw("Horizontal"));

            if (movementDirection != Vector3.zero)
            {
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(movementDirection), 0.15f);

            }

        }
    }



    void movePlayer(Vector3 movement)
    {
        if (rigidBody.velocity.magnitude * acceleration > maxSpeed)
        {
            rigidBody.AddForce(movement * -1);
        }
        else
        {
            rigidBody.AddForce(movement);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        
        TimeEnemy timeEnemy = collision.collider.gameObject.GetComponent<TimeEnemy>();
        if (timeEnemy)
        {
            collidedWithEnemy(timeEnemy);
        }
        if (collision.gameObject.tag == "Gant")
        {
            collidedWithGant();
        }
        
    }

    void collidedWithGant()
    {

        if (onClassReached != null)
        {
            onClassReached(this);
        }
    }

    void collidedWithEnemy(TimeEnemy timeEnemy)
    {
        timeEnemy.Attack(this);

        if (health <= 0)
        {
            if (onPlayerDeath != null)
            {
                onPlayerDeath(this);
            }

        }
    }
}
