using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    [SerializeField]
    public static float worldRadius = 200;
    public static PlayerControl player = null;
    public static Transform motherTransform = null;
    public static GameObject canvas = null;
    private GameObject mainMenu = null;
    private GameObject endUI = null;
    [SerializeField]
    public float warmUpTime = 0;
    [System.NonSerialized]
    public bool gameStarted = false;
    private Selectable startButton;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector3.zero;
        AudioListener.volume = 0;
        Camera.main.cullingMask = 1 << LayerMask.NameToLayer("Player");
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
        motherTransform = GameObject.Find("Mother").transform;
        canvas = GameObject.Find("Canvas");
        mainMenu = GameObject.Find("Main Menu");
        endUI = GameObject.Find("End");
        endUI.SetActive(false);
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
        while(Time.timeSinceLevelLoad < warmUpTime) {
            yield return new WaitForSeconds(warmUpTime);
        }
        Time.timeScale = 1;
        startButton.interactable = true;
        yield return null;
    }

    public void EnterGame()
    {
        if(gameStarted) {
            canvas.SetActive(false);
        } else {
            player.PutShipInStartPosition();
            Camera.main.cullingMask = -1;
            startButton.transform.Find("Text").GetComponent<Text>().text = "continue";
            Canvas.ForceUpdateCanvases();
            canvas.SetActive(false);
            AudioListener.volume = 1;
            gameStarted = true;
        }
    }

    public IEnumerator OpenEndUI(float delay=0)
    {
        yield return new WaitForSeconds(delay);
        gameStarted = false;
        mainMenu.SetActive(false);
        endUI.SetActive(true);
        Camera.main.cullingMask = 1 << LayerMask.NameToLayer("UI");
        AudioListener.volume = 0;
        canvas.SetActive(true);
        endUI.transform.Find("restart").GetComponent<Selectable>().Select();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
