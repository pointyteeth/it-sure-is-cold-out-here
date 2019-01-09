using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    [SerializeField]
    protected float minScale = 1;
    [SerializeField]
    protected float maxScale = 1;

    [SerializeField]
    protected Gradient colorRange = new Gradient();

    [SerializeField]
    private bool hasAudio = false;
    [SerializeField]
    private AudioClip[] audioClips = null;
    protected AudioSource audioSource = null;

    // Start is called before the first frame update
    protected void Start()
    {
        transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
        if(hasAudio) {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
            StartCoroutine("SyncAudio");
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if(hasAudio) {
            audioSource.priority = (int) Mathf.Lerp(0, 256, Vector3.Distance(transform.position, PlayerControl.playerTransform.position)/(Main.worldRadius*2));
        }
    }

    IEnumerator SyncAudio() {
        audioSource.time = Mathf.Repeat(Time.time, audioSource.clip.length);
        yield return new WaitForSeconds(1);
    }
}
