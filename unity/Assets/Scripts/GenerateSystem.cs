﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSystem : MonoBehaviour
{

    [SerializeField]
    private BodySet starSet = null;
    [SerializeField]
    public static float orbitTrailAmount = 0.9f;
    [SerializeField]
    private BodySet moon1Set = null;
    [SerializeField]
    private BodySet moon2Set = null;
    [SerializeField]
    private BodySet moon3Set = null;

    // Start is called before the first frame update
    void Start()
    {
        moon1Set.Setup(this.transform);
        for(int i = 0; i < moon1Set.list.Length; i++) {
            moon2Set.Setup(moon1Set.list[i].transform);
            for(int j = 0; j < moon2Set.list.Length; j++) {
                moon3Set.Setup(moon2Set.list[j].transform);
            }
        }
        starSet.Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
class BodySet : System.Object
{
    [SerializeField]
    private Body bodyPrefab = null;
    [System.NonSerialized]
    public Body[] list = new Body[0];

    public void Setup(Transform parent=null)
    {
        bodyPrefab.numBodies = Random.Range(bodyPrefab.minNumber, bodyPrefab.maxNumber + 1);
        if(bodyPrefab.numBodies > 0) {
            list = new Body[bodyPrefab.numBodies];
            for(int i = 0; i < bodyPrefab.numBodies; i++) {
                list[i] = GameObject.Instantiate(bodyPrefab);
                list[i].name = bodyPrefab.name + " " + i;
                list[i].transform.parent = parent;
                list[i].numBodies = bodyPrefab.numBodies;
                list[i].index = i;
            }
        }
    }
}
