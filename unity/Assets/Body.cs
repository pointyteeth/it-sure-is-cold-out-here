using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    [SerializeField]
    protected float minScale = 1;
    [SerializeField]
    protected float maxScale = 1;

    [SerializeField]
    protected Gradient colorRange = new Gradient();

    [SerializeField]
    protected float minRotationSpeed = 0;
    [SerializeField]
    protected float maxRotationSpeed = 0;
    protected float rotationSpeed = 0;

    // Start is called before the first frame update
    protected void Start()
    {
        //transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
