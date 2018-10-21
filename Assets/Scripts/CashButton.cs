using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CashButton : NetworkBehaviour {

    public GameObject cashText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cashButton()
    {
        DataBase.cash++;
        cashText.GetComponent<Text>().text = "" + DataBase.cash;
    }
}
