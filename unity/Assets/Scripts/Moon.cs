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
    [System.NonSerialized]
    public float orbitSpeed = 0;

    private Transform parentTransform = null;

    // Start is called before the first frame update
    new void Start()
    {//TODO: PUT SOME OF THIS SHIT IN AWAKE?? I THINK THE SIZE IS CORRECT, IT'S JUST THE ORBITRADIUS THAT'S OFF
        base.Start();
        parentTransform = transform.parent;
        orbitRadius = Random.Range(minOrbitRadius, maxOrbitRadius);
        transform.localPosition = Vector3.zero;
        transform.Translate(Vector3.up * orbitRadius);
        orbitSpeed = Random.Range(minOrbitSpeed, maxOrbitSpeed);
        transform.RotateAround(parentTransform.position, Vector3.forward, Random.Range(0, 360));
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.RotateAround(parentTransform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }
}
