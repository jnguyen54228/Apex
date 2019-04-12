using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class TurnManager : NetworkBehaviour {

    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building 1", employeesLost = 0},
        new Building(){ buildingName = "Office Building 2", employeesLost = 0},
        new Building(){ buildingName = "Convenience Store 1", employeesLost = 0},
        new Building(){ buildingName = "Convenience Store 2", employeesLost = 0},
        new Building(){ buildingName = "Apartment Building 1", employeesLost = 0},
        new Building(){ buildingName = "Apartment Building 2", employeesLost = 0},
        new Building(){ buildingName = "Trade Center 1", employeesLost = 0},
        new Building(){ buildingName = "Trade Center 2", employeesLost = 0},
        new Building(){ buildingName = "Club", employeesLost = 0},
        new Building(){ buildingName = "Super Market", employeesLost = 0},
        new Building(){ buildingName = "Church", employeesLost = 0},
        new Building(){ buildingName = "Movie Theater", employeesLost = 0}
    };

    public GameObject waitPanel;
    public GameObject employeeModeEmployeesText;
    public GameObject employeeModeBuildingInfoEmployeesText;
    public GameObject totalEmployeesText;
    public GameObject totalRevenueText;
    public GameObject employeeModeRevenueText;
    public GameObject updateText;

    int ranNum;
    int initialEmployeesOwned;

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

                    initialEmployeesOwned = DataBase.buildingsList[i].employeesOwned;

                    for (int ii = 0; ii < initialEmployeesOwned; ii++) //sims through each employee of the building
                    {
                        ranNum = Random.Range(1, 101); // creates random number from 1 - 100
                        if (ranNum <= DataBase.buildingsList[i].leaveRate)
                        {
                            buildingsList[i].employeesLost++;

                            DataBase.buildingsList[i].employeesOwned--;
                            DataBase.employeesOwned--;
                            EmployeeMode.adjustedNumberOfEmployees--;
                            employeeModeBuildingInfoEmployeesText.GetComponent<Text>().text = DataBase.buildingsList[i].employeesOwned.ToString();
                            totalEmployeesText.GetComponent<Text>().text = DataBase.employeesOwned.ToString();

                            DataBase.buildingsList[i].revenue -= DataBase.buildingsList[i].employeeCap;
                            DataBase.totalRevenue -= DataBase.buildingsList[i].employeeCap;
                            totalRevenueText.GetComponent<Text>().text = DataBase.totalRevenue.ToString();
                            employeeModeRevenueText.GetComponent<Text>().text = DataBase.buildingsList[i].revenue.ToString();
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

                    initialEmployeesOwned = DataBase.buildingsList[i].employeesOwned;

                    for (int ii = 0; ii < initialEmployeesOwned; ii++) //sims through each employee of the building
                    {
                        ranNum = Random.Range(1, 101); // creates random number from 1 - 100
                        if (ranNum <= DataBase.buildingsList[i].leaveRate)
                        {
                            buildingsList[i].employeesLost++;

                            DataBase.buildingsList[i].employeesOwned--;
                            DataBase.employeesOwned--;
                            EmployeeMode.adjustedNumberOfEmployees--;
                            employeeModeBuildingInfoEmployeesText.GetComponent<Text>().text = DataBase.buildingsList[i].employeesOwned.ToString();
                            totalEmployeesText.GetComponent<Text>().text = DataBase.employeesOwned.ToString();

                            DataBase.buildingsList[i].revenue -= DataBase.buildingsList[i].employeeCap;
                            DataBase.totalRevenue -= DataBase.buildingsList[i].employeeCap;
                            totalRevenueText.GetComponent<Text>().text = DataBase.totalRevenue.ToString();
                            employeeModeRevenueText.GetComponent<Text>().text = DataBase.buildingsList[i].revenue.ToString();
                        }
                    }
                }
            }
        }

        for (int i = 0; i < buildingsList.Count; i++) {
            if (buildingsList[i].employeesLost > 0) {
                updateText.GetComponent<Text>().text += (buildingsList[i].buildingName + " lost " + buildingsList[i].employeesLost + " employee(s) ");
            }
        }
    }

    public class Building
    {
        public string buildingName { get; set; }
        public int employeesLost { get; set; }
    }
}
