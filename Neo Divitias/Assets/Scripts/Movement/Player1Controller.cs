using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerController {
    PlayerHealth playerHealth;
    Rigidbody body;
    Vector3 forward, right;
    float distToGround;

    void Start () {
        playerHealth = GetComponent<PlayerHealth>();
        body = GetComponent<Rigidbody>();
        forward = transform.forward;
        right = transform.right;
	}
	
	void FixedUpdate () {
        // Get speed and max velocity
        float moveSpeedCurrent = moveSpeed;
        float maxVelocityCurrent = maxVelocity;

        if (Input.GetButton("Sprint p1") || Input.GetButton("Sprint"))
        {
            moveSpeedCurrent *= sprintMultiplier;
        }

        // Aim in direction of camera
        forward = currentCamera.transform.forward;
        forward.y = 0;
        right = currentCamera.transform.right;
        right.y = 0;

        // Clamp horizontal velocity
    }

    void Update()
    {
    }

    bool isGrounded ()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.2f);
    }
}
