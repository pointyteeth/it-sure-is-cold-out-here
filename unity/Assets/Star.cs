﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Body
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Random.insideUnitCircle * Main.worldRadius;
    }

    // Update is called once per frame
    void Update()
    {

    }
}