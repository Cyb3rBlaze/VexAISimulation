using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    private bool interactMode;
    private Rigidbody body;

    //Displacement variables used to set velocity of the userRobot
    private float deltaTurn;

    void Start()
    {
        interactMode = true;
        body = GetComponent<Rigidbody>();
    }

    //Fixed Update allows accurate physics as well as consistant rendering
    void FixedUpdate()
    {
        //Specific to the interact state
        if (interactMode) {
            //Used to make sure the robot remains on one plane
            this.transform.position = new Vector3(this.transform.position.x, 0.06f, this.transform.position.z);
            this.transform.eulerAngles = new Vector3(0f, this.transform.eulerAngles.y, 0f);

            //Resetting physics values
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;

            //Used to calculate displacement values
            float angle = this.transform.eulerAngles.y;

            //Forward-Backward movement
            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.velocity = new Vector3(1, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                body.velocity = new Vector3(-1, 0f, 0f);
            }

            //Left-Right movement
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                body.velocity = new Vector3(0f, 0f, 1);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                body.velocity = new Vector3(0f, 0f, -1);
            }

            //Turning movement
            if (Input.GetKey(KeyCode.A))
            {
                float turn = Input.GetAxis("Horizontal");
                body.AddTorque(transform.up * 120 * turn);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                float turn = Input.GetAxis("Horizontal");
                body.AddTorque(transform.up * 120 * turn);
            }
        }
    }
}
