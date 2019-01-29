using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    [SerializeField]
    public static float worldRadius = 200;
    public static PlayerControl player = null;
    public static Transform motherTransform = null;
    public static GameObject canvas = null;
    [SerializeField]
    public float warmUpTime = 0;
    [System.NonSerialized]
    public bool gameStarted = false;
    private Selectable startButton;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector3.zero;
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        motherTransform = GameObject.Find("Mother").transform;
        canvas = GameObject.Find("Canvas");
        StartCoroutine("WarmUpTrails");
        startButton = GameObject.Find("start").GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Cancel")) {
            if(canvas.activeSelf && gameStarted) {
                canvas.SetActive(false);
            } else if(!canvas.activeSelf) {
                canvas.SetActive(true);
            }
            startButton.Select();
        }
    }

    IEnumerator WarmUpTrails()
    {
        Time.timeScale = 100;
        while(Time.time < warmUpTime) {
            yield return new WaitForSeconds(warmUpTime);
        }
        Time.timeScale = 1;
        startButton.interactable = true;
        yield return null;
    }

    public void StartGame()
    {
        player.PutShipInStartPosition();
        canvas.SetActive(false);
        gameStarted = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
