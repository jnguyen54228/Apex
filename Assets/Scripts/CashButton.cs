using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashButton : MonoBehaviour {

    int cash = 0;
    public GameObject cashText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cashButton()
    {
        cash++;
        cashText.GetComponent<Text>().text = "" + cash;
    }
}
