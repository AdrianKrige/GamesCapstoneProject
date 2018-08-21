using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    public bool active = false;
    private CharacterController rb;
    public float mouseSensitivity = 2;
    public GameObject cam;
    float VertRot = 0;
    public float UDRange = 75.0f;

    void Start ()
    {
        rb = GetComponent<CharacterController>();
        Screen.lockCursor = true;
    }

    void FixedUpdate ()
    {
        if (active) {
            // Rotation
            float rotLR = Input.GetAxis ("Mouse X");

            transform.Rotate (0, rotLR * mouseSensitivity, 0);
            VertRot += Input.GetAxis("Mouse Y") * mouseSensitivity;
            VertRot = Mathf.Clamp (VertRot, -UDRange, UDRange);
            cam.transform.localRotation = Quaternion.Euler (VertRot * -1, 0, 0);


            // Movement
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

            movement = transform.rotation * movement;

            rb.SimpleMove (movement * speed);
        }
    }
}
