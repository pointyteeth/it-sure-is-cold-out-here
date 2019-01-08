using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    [SerializeField]
    public static float worldRadius = 200;
    [SerializeField]
    public float warmUpTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector3.zero;
        StartCoroutine("WarmUpTrails");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator WarmUpTrails() {
        Time.timeScale = 100;
        while(Time.time < warmUpTime) {
            yield return new WaitForSeconds(warmUpTime);
        }
        Time.timeScale = 1;
        yield return null;
    }
}
