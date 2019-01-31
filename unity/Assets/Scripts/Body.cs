using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    public int minNumber = 0;
    public int maxNumber = 0;
    [System.NonSerialized]
    public int numBodies = 0;

    [SerializeField]
    protected float minScale = 1;
    [SerializeField]
    protected float maxScale = 1;

    [System.NonSerialized]
    public int index = 0;

    /*[SerializeField]
    protected Gradient colorRange = new Gradient();*/

    [SerializeField]
    private bool hasAudio = false;
    [SerializeField]
    private AudioClip[] audioClips = null;
    protected AudioSource audioSource = null;

    [SerializeField]
    private Sprite[] faceSprites = null;
    protected Sprite faceSprite = null;

    protected void Awake() {
        transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
    }

    // Start is called before the first frame update
    protected void Start()
    {
        if(hasAudio) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            StartCoroutine("SyncAudio");
        }
        faceSprite = faceSprites[Random.Range(0, faceSprites.Length)];
        transform.Find("Face").GetComponent<SpriteRenderer>().sprite = faceSprite;
    }

    // Update is called once per frame
    protected void Update()
    {
        if(hasAudio) {
            audioSource.priority = (int) Mathf.Lerp(0, 256, Vector3.Distance(transform.position, Main.player.transform.position)/(Main.worldRadius*2));
        }
    }

    IEnumerator SyncAudio() {
        audioSource.time = Mathf.Repeat(Time.time, audioSource.clip.length);
        yield return new WaitForSeconds(1);
    }
}
