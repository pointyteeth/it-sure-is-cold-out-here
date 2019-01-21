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

    [SerializeField]
    protected Texture[] textures = null;

    private Transform parentTransform = null;

    new void Awake() {
        base.Awake();
        transform.rotation = Random.rotation;
    }

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        parentTransform = transform.parent;
        float spacing = (maxOrbitRadius - minOrbitRadius)/numBodies;
        orbitRadius = minOrbitRadius + spacing * index + Random.Range(0, spacing/2);
        transform.localPosition = Vector3.zero;
        transform.Translate(Vector3.up * orbitRadius, Space.World);
        orbitSpeed = Random.Range(minOrbitSpeed, maxOrbitSpeed);
        if(Random.value > 0.5f) orbitSpeed *= -1;
        transform.RotateAround(parentTransform.position, Vector3.forward, Random.Range(0, 360));
        Material material = GetComponent<Renderer>().material;
        material.SetTexture("_MainTex", textures[Random.Range(0, textures.Length)]);
        material.SetFloat("_Outline", material.GetFloat("_Outline")/transform.lossyScale.x);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        transform.RotateAround(parentTransform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }
}
