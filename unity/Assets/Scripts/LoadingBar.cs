using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    Image image = null;
    private float fullWidth = 0;
    private Main main = null;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        fullWidth = image.rectTransform.rect.width;
        main = GameObject.Find("Main").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        image.rectTransform.sizeDelta = new Vector2(Mathf.Lerp(0, fullWidth, Time.time/main.warmUpTime), image.rectTransform.sizeDelta.y) ;

    }
}
