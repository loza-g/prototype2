using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class Bar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bar;
    public GameObject WIN;
    public int time;

    void Start()
    {
        AnimateBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time).setOnComplete(ShowYouWinImage);
    }

    void ShowYouWinImage()
    {
        // Activate the "You Win" image to make it visible.
        WIN.SetActive(true);
        Time.timeScale = 0;
    }
}
