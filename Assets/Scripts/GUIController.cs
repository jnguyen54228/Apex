using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GUIController : NetworkBehaviour {

    public GameObject purchaseScreen;
    public GameObject employeeScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject updateScreen;
    public GameObject hackingScreen;

	// Use this for initialization
	void Start () {
        purchaseScreen.SetActive(false);
        employeeScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (DataBase.newTurn == false)
        {
            updateScreen.SetActive(false);
        }
        if (DataBase.serverWin == true)
        {
            if (isServer)
            {
                updateScreen.SetActive(false);
                winScreen.SetActive(true);
            }
            else if(!isServer)
            {
                updateScreen.SetActive(false);
                loseScreen.SetActive(true);
            }
        }
        else if (DataBase.clientWin == true)
        {
            if (!isServer)
            {
                updateScreen.SetActive(false);
                winScreen.SetActive(true);
            }
            else if(isServer)
            {
                updateScreen.SetActive(false);
                loseScreen.SetActive(true);
            }
        }
        else if (DataBase.newTurn == true)
        {
            updateScreen.SetActive(true);
        }
	}

    public void ClosePurchaseScreen() {
        purchaseScreen.SetActive(false);
    }

    public void CloseEmployeeScreen()
    {
        employeeScreen.SetActive(false);
    }

    public void CloseUpdateScreen() {
        DataBase.newTurn = false;
    }
}
