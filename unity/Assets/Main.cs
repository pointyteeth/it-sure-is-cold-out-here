using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    [SerializeField]
    public static float worldRadius = 200;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
