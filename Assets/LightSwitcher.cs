using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitcher : MonoBehaviour {

    public GameObject lightBulb;
    public GameObject switchOn;
    public GameObject switchOff;

	// Use this for initialization
	void Start () {
        switchOn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnMouseDown()
    {
        if(gameObject.name == "Off Switch")
        {
            lightBulb.GetComponent<Image>().color = Color.yellow;
            switchOn.SetActive(true);
            switchOff.SetActive(false);
        }
        else if(gameObject.name == "On Switch")
        {
            lightBulb.GetComponent<Image>().color = Color.white;
            switchOff.SetActive(true);
            switchOn.SetActive(false);
        }
    }
}
