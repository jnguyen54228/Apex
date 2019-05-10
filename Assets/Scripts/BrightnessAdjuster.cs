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
        brightnessSlider.GetComponent<Slider>().value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = brightnessPanel.GetComponent<Image>().color;

        if (brightnessSlider.GetComponent<Slider>().value > 0.2)
        {
            color.a = 1 - brightnessSlider.GetComponent<Slider>().value;
        }
        else {
            //nothing
        }

        brightnessPanel.GetComponent<Image>().color = color;
    }
}
