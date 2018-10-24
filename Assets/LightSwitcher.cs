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

    public void OnSwitch()
    {
        switchOn.SetActive(false);
        switchOff.SetActive(true);
        lightBulb.GetComponent<Image>().color = Color.white;
    }

    public void OffSwitch()
    {
        switchOff.SetActive(false);
        switchOn.SetActive(true);
        lightBulb.GetComponent<Image>().color = Color.yellow;
    }
}
