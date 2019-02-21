using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GUIController : NetworkBehaviour {

    public GameObject purchaseScreen;
    public GameObject employeeScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

	// Use this for initialization
	void Start () {
        purchaseScreen.SetActive(false);
        employeeScreen.SetActive(false)
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (DataBase.serverWin == true)
        {
            if (isServer)
            {
                winScreen.SetActive(true);
            }
            else
            {
                loseScreen.SetActive(true);
            }
        }
        else if (DataBase.clientWin == true) {
            if (isClient)
            {
                winScreen.SetActive(true);
            }
            else {
                loseScreen.SetActive(true);
            }
        }
	}

    public void ClosePurchaseScreen() {
        purchaseScreen.SetActive(false);
    }

    public void CloseEmployeeScreen()
    {
        employeeScreen.SetActive(false);
    }
}
