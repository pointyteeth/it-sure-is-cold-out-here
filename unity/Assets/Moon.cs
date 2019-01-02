using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : Body
{

    [SerializeField]
    private float minOrbitRadius = 0;
    [SerializeField]
    private float maxOrbitRadius = 0;
    private float orbitRadius = 0;

    [SerializeField]
    private float minOrbitSpeed = 0;
    [SerializeField]
    private float maxOrbitSpeed = 0;
    private float orbitSpeed = 0;

    private Transform parentTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        orbitRadius = Random.Range(minOrbitRadius, maxOrbitRadius);
        transform.position = Vector3.up * orbitRadius;
        orbitSpeed = Random.Range(minOrbitSpeed, maxOrbitSpeed);
        parentTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        transform.RotateAround(parentTransform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }
}
