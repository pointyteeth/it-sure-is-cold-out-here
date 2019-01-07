using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    new private Rigidbody2D rigidbody;
    GameObject ship;

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float rotationSpeed = 0f;
    [SerializeField]
    private float shipRotationSpeed = 0f;
    [SerializeField]
    private float maxShipRotation = 0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ship = GameObject.Find("Ship");
        transform.position = Vector3.up * (Main.worldRadius - 10);
        transform.RotateAround(Vector3.zero, Vector3.forward, Random.Range(0, 360));
        GetComponent<DistanceJoint2D>().distance = Main.worldRadius;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump")) { //Thrust
            rigidbody.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift)) { //Reverse Thrust
            rigidbody.AddRelativeForce(Vector2.down * speed * Time.deltaTime);
        }
        float direction = -Input.GetAxis("Horizontal");
        rigidbody.AddTorque(direction * rotationSpeed * Time.deltaTime); //Turn
        float rotation = ship.transform.localRotation.eulerAngles.y;
        if(rotation > 180) rotation -= 360;
        if((direction < 0 && rotation > -maxShipRotation) || (direction > 0 && rotation < maxShipRotation)) { //Roll ship model
            ship.transform.Rotate(Vector3.up * shipRotationSpeed * direction * Time.deltaTime);
        } else if(direction == 0) {
            ship.transform.localRotation = Quaternion.RotateTowards(ship.transform.localRotation, Quaternion.identity, Time.deltaTime * shipRotationSpeed);
        }
    }
}
