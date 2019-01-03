using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSystem : MonoBehaviour
{

    [SerializeField]
    private BodySet starSet = null;
    [SerializeField]
    private BodySet moon1Set = null;
    [SerializeField]
    private BodySet moon2Set = null;

    // Start is called before the first frame update
    void Start()
    {
        starSet.Setup(transform);
        moon1Set.Setup(transform);
        for(int i = 0; i < moon1Set.list.Length; i++) {
            moon2Set.Setup(moon1Set.list[i].transform);
        }
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
    public Body[] list = null;
    [SerializeField]
    private int minNumber = 0;
    [SerializeField]
    private int maxNumber = 0;
    private int numBodies = 0;

    public void Setup(Transform parent)
    {
        numBodies = Random.Range(minNumber, maxNumber);
        list = new Body[numBodies];
        for(int i = 0; i < numBodies; i++) {
            list[i] = GameObject.Instantiate(bodyPrefab);
            list[i].transform.parent = parent;
            list[i].name = bodyPrefab.name + " " + i;
        }
    }
}
