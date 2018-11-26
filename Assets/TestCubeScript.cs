using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubeScript : MonoBehaviour {

    public static bool button1Press;
    public static bool button2Press;

	void Start () {
        button1Press = false;
        button2Press = false;
	}
	
	void Update () {
		
	}

    public void ButtonPress()
    {
        if (gameObject.name == "Button 1")
        {
            button1Press = true;
        }
        else if (gameObject.name == "Button 2") {

            button2Press = true;
        }
    }
}
