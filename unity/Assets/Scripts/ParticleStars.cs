using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule newShape = ps.shape;
        newShape.radius = Main.worldRadius;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
