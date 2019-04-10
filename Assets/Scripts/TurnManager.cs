using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class TurnManager : NetworkBehaviour {

    public GameObject waitPanel;
    public GameObject employeeModeEmployeesText;
    public GameObject employeeModeBuildingInfoEmployeesText;
    public GameObject totalEmployeesText;

    int ranNum;

    // Use this for initialization
    void Start()
    {
        waitPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (isServer) {
            if (DataBase.clientWin == true) {
                waitPanel.SetActive(false);
            }
            else if (DataBase.turn == "server")    //if the it's the server's turn on the server's computer,                                        
            {                                      //they are free to do what ever they want 
                waitPanel.SetActive(false);
                Cursor.visible = true;
            }
            else if(DataBase.turn == "client"){             //however if it's the client's turn on the server's computer,
                waitPanel.SetActive(true);                  //the server;s computer is locked 
                Cursor.visible = false;
            }
        }
        else if (!isServer)
        {
            if (DataBase.serverWin == true)
            {
                waitPanel.SetActive(false);
            }
            else if (DataBase.turn == "client") {
                waitPanel.SetActive(false);
                Cursor.visible = true;
            }
            else if(DataBase.turn == "server")
            {
                waitPanel.SetActive(true);
                Cursor.visible = false;
            }
        }
    }

    public void EndTurn()  //function that runs when the end turn button is pressed     
    {                           
        if (isServer)           
        {
            DataBase.turn = "client"; 
            DataBase.serverTurnEnded = true; //triggers code to run in the PlayerController 

            for (int i = 0; i < DataBase.buildingsList.Count; i++) {
                if (DataBase.buildingsList[i].owner == "Server" && DataBase.buildingsList[i].employeesOwned > 0) {
                    for (int ii = 0; ii < DataBase.buildingsList[i].employeesOwned; ii++) //sims through each employee of the building
                    {
                        ranNum = Random.Range(1, 101); // creates random number from 1 - 100
                        if (ranNum <= DataBase.buildingsList[i].leaveRate)
                        {
                            DataBase.buildingsList[i].employeesOwned--;
                            DataBase.employeesOwned--;
                            employeeModeEmployeesText.GetComponent<Text>().text = DataBase.buildingsList[i].employeesOwned.ToString();
                            employeeModeBuildingInfoEmployeesText.GetComponent<Text>().text = DataBase.buildingsList[i].employeesOwned.ToString();
                            totalEmployeesText.GetComponent<Text>().text = DataBase.employeesOwned.ToString();
                        }
                    }
                }
            }
        }
        else if (!isServer) {
            DataBase.turn = "server";
            DataBase.clientTurnEnded = true;

            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                if (DataBase.buildingsList[i].owner == "Client" && DataBase.buildingsList[i].employeesOwned > 0)
                {
                    for (int ii = 0; ii < DataBase.buildingsList[i].employeesOwned; ii++) //sims through each employee of the building
                    {
                        ranNum = Random.Range(1, 101); // creates random number from 1 - 100
                        if (ranNum <= DataBase.buildingsList[i].leaveRate)
                        {
                            DataBase.buildingsList[i].employeesOwned--;
                            DataBase.employeesOwned--;
                            employeeModeEmployeesText.GetComponent<Text>().text = DataBase.buildingsList[i].employeesOwned.ToString();
                            employeeModeBuildingInfoEmployeesText.GetComponent<Text>().text = DataBase.buildingsList[i].employeesOwned.ToString();
                            totalEmployeesText.GetComponent<Text>().text = DataBase.employeesOwned.ToString();
                        }
                    }
                }
            }
        }
    }
}
