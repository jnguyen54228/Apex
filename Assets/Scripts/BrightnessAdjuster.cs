using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessAdjuster : MonoBehaviour
{
    public GameObject brightnessPanel;
    public GameObject brightnessSlider;

    // Start is called before the first frame update
    void Start() { 

    }

    // Update is called once per frame
    void Update()
    {
        Color color = brightnessPanel.GetComponent<Image>().color;
        color.a = brightnessSlider.GetComponent<Slider>().value;

        brightnessPanel.GetComponent<Image>().color = color;
    }
}
