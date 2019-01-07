using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Body
{

    [SerializeField]
    private float minRotationSpeed = 0;
    [SerializeField]
    private float maxRotationSpeed = 0;
    private float rotationSpeed = 0;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        transform.position = Random.insideUnitCircle * Main.worldRadius;
    }

    // Update is called once per frame
    new void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
