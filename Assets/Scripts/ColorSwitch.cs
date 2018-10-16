using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwitch : MonoBehaviour
{

    public GameObject button1;
    public GameObject button2;

    bool isPressed1 = false;
    bool isPressed2 = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Button1Press()
    {
        if (isPressed1 == false)
        {
            button1.GetComponent<Image>().color = Color.black;
            isPressed1 = true;
        }
        else
        {
            button1.GetComponent<Image>().color = Color.white;
            isPressed1 = false;
        }
    }

    public void Button2Press()
    {
        if (isPressed2 == false)
        {
            button2.GetComponent<Image>().color = Color.black;
            isPressed2 = true;
        }
        else
        {
            button2.GetComponent<Image>().color = Color.white;
            isPressed2 = false;
        }
    }

}