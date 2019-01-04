using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Body
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        transform.position = Random.insideUnitCircle * Main.worldRadius;
    }
}
