using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D shipRigidbody;
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
        shipRigidbody = GetComponent<Rigidbody2D>();
        ship = GameObject.Find("Ship");
        GetComponent<DistanceJoint2D>().distance = Main.worldRadius;
    }

    public void PutShipInStartPosition() {
        transform.position = Vector3.up * (Main.worldRadius - 10);
        transform.RotateAround(Vector3.zero, Vector3.forward, Random.Range(0, 360));
        transform.Rotate(Vector3.forward * 180);
        shipRigidbody.simulated = true;
    }

    void FixedUpdate()
    {
        shipRigidbody.AddRelativeForce(Vector2.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        float direction = -Input.GetAxis("Horizontal");
        shipRigidbody.AddTorque(direction * rotationSpeed * Time.deltaTime); //Turn
        float rotation = ship.transform.localRotation.eulerAngles.y;
        if(rotation > 180) rotation -= 360;
        if((direction < 0 && rotation > -maxShipRotation) || (direction > 0 && rotation < maxShipRotation)) { //Roll ship model
            ship.transform.Rotate(Vector3.up * shipRotationSpeed * direction * Time.deltaTime);
        } else if(direction == 0) {
            ship.transform.localRotation = Quaternion.RotateTowards(ship.transform.localRotation, Quaternion.identity, Time.deltaTime * shipRotationSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Mother")
        {
            GetComponent<PlayerLand>().enabled = true;
            this.enabled = false;
        }
    }
}
