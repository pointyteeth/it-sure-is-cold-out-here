using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLand : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    [SerializeField]
    private float rotationTime = 0;
    [SerializeField]
    private float maxRotationSpeed = 0;
    [SerializeField]
    private float angleError = 0;
    [SerializeField]
    private float backUpSpeed = 0;
    private bool facingAwayFromPlanet = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine("BackUp");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RotateToFacePlanet() {
        float goalAngle = 0;
        float currentVelocity = 0;
        float currentAngle = 0;
        do {
            goalAngle = Vector3.SignedAngle(Vector3.up, transform.position, Vector3.forward);
            currentAngle = AngleMagic(transform.localRotation.eulerAngles.z);
            transform.rotation = Quaternion.AngleAxis(Mathf.SmoothDamp(currentAngle, goalAngle, ref currentVelocity, rotationTime, maxRotationSpeed),Vector3.forward);
            yield return null;
        } while(Mathf.Abs(goalAngle - currentAngle) > angleError);
        facingAwayFromPlanet = true;
        StartCoroutine("BackUp");
        yield return null;
    }

    IEnumerator BackUp() {
        do {
            shipRigidbody.AddRelativeForce(Vector2.down * backUpSpeed * Time.deltaTime);
            yield return null;
        } while(Vector3.Distance(transform.position, Main.motherTransform.position) < (Main.motherTransform.localScale.x + transform.localScale.x * 1.5)/2);
        StartCoroutine("RotateToFacePlanet");
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Mother" && facingAwayFromPlanet)
        {
            StopCoroutine("BackUp");
            shipRigidbody.simulated = false;
        }
    }

    float AngleMagic(float angle) {
        angle = Mathf.Repeat(angle, 360);
        if(angle > 180) angle -= 360;
        return angle;
    }
}
