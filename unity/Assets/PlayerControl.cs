using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    new private Rigidbody2D rigidbody;

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float rotateSpeed = 0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump")) { //Spacebar by default will make it move forward
            rigidbody.AddRelativeForce(Vector2.up*speed);
        }
    }
}
