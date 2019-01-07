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

    // Start is called before the first frame update
    protected void Start()
    {
        //transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
    }

    // Update is called once per frame
    protected void Update()
    {
    }
}
