using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 0f;
    [SerializeField]
    private float orbitSpeed = 0f;
    private Transform parentTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent != null) {
            parentTransform = transform.parent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        if(parentTransform != null) {
            transform.RotateAround(parentTransform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
        }
    }
}
