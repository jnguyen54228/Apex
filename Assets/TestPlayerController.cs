using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestPlayerController : NetworkBehaviour {

    [SyncVar]
    public bool button1Press = false;
    [SyncVar]
    public bool button2Press = false;

	void Start () {
	}
	
	void Update () {
        if (button1Press == true)
        {
            GameObject.Find("Cube 1").transform.position = new Vector3(-3, 3, 0);
        }
        else if (button2Press == true)
        {
            GameObject.Find("Cube 2").transform.position = new Vector3(3, 3, 0);
        }
	}

    public void ButtonPress1()
    {
        button1Press = true;
    }

    public void ButtonPress2()
    {
        button2Press = true;
    }
}
