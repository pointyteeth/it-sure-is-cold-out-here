using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailParticles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule newMain = ps.main;
        newMain.simulationSpace = ParticleSystemSimulationSpace.Custom;
        newMain.customSimulationSpace = transform.parent.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
