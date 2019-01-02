using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSystem : MonoBehaviour
{

    [SerializeField]
    private Moon moon1Prefab = null;
    [SerializeField]
    private int minNumberOfMoon1s = 0;
    [SerializeField]
    private int maxNumberOfMoon1s = 0;
    private int numberOfMoon1s;
    private Moon[] moon1 = null;

    [SerializeField]
    private Star starPrefab = null;
    [SerializeField]
    private int minNumberOfStars = 0;
    [SerializeField]
    private int maxNumberOfStars = 0;
    private int numberOfStars;
    private Star[] star = null;

    // Start is called before the first frame update
    void Start()
    {
        numberOfMoon1s = Random.Range(minNumberOfMoon1s, maxNumberOfMoon1s);
        moon1 = new Moon[numberOfMoon1s];
        for(int i = 0; i < numberOfMoon1s; i++) {
            moon1[i] = Instantiate(moon1Prefab);
            moon1[i].transform.parent = transform;
        }


        numberOfStars = Random.Range(minNumberOfStars, maxNumberOfStars);
        star = new Star[numberOfStars];
        for(int i = 0; i < numberOfStars; i++) {
            star[i] = Instantiate(starPrefab);
            star[i].transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
