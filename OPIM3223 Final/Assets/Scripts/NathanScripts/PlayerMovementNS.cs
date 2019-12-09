using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNS : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;
    public float jumpspeed;
    public float jumpheight;
    public bool isgrounded;
    private Rigidbody rigidBody;
    private KeyCode[] inputKeys;
    private Vector3[] keyDirections;

    // Start is called before the first frame update
    void Start()
    {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space };
        keyDirections = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right, Vector3.up };
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay()
    {
        isgrounded = true;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            var currentKey = inputKeys[i];
            if (Input.GetKey(currentKey))
                if (Input.GetKey(currentKey))

                {

                    Vector3 move = keyDirections[i] * acceleration * Time.deltaTime;
                    movePlayer(move);
                }
            if (Input.GetKey(KeyCode.Space) && isgrounded)
            {
                rigidBody.AddForce(Vector3.up * jumpspeed * jumpheight);
                isgrounded = false;

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
}
   