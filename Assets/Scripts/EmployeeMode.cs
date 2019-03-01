using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EmployeeMode : NetworkBehaviour
{
    public GameObject employeeModeButton;
    public GameObject purchaseScreen;
    public GameObject employeeScreen;
    public GameObject buildingName;
    public GameObject employeeNumber;
    public GameObject buildingInfoEmployees;
    public GameObject buildingInfoEmployeeCap;
    public bool addEmployee;
    public bool removeEmployee;
    public int adjustedNumberOfEmployees = 0;
    public string localCurrentBuilding = null;

    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10, employeeCap = 10, employeesOwned = 0},
        new Building(){ buildingName = "Office Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 10, employeeCap = 10, employeesOwned = 0},
        new Building(){ buildingName = "Convenience Store 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0},
        new Building(){ buildingName = "Convenience Store 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35, employeeCap = 15, employeesOwned = 0},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35, employeeCap = 15, employeesOwned = 0},
        new Building(){ buildingName = "Club", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0},
        new Building(){ buildingName = "Super Market", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0},
        new Building(){ buildingName = "Church", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0},
        new Building(){ buildingName = "Movie Theater", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0}
    };


    void Start()
    {
    }

    /*void Update()
    {
        if (DataBase.employeeModeIsActivated == true) {
            employeeScreen.SetActive(true);
            buildingName.GetComponent<Text>().text = DataBase.currentBuilding;
        }
        else if(DataBase.employeeModeIsActivated == false)
        {
            employeeScreen.SetActive(false);
        }
    }*/

    void Update()
    {
        if (DataBase.employeeModeIsActivated == true)
        {
            if (localCurrentBuilding == null) {
                //nothing
            }
            else if (DataBase.currentBuilding != localCurrentBuilding) { //make sure that the info changes to match the correct info when a new building is clicked on

                for (int i = 0; i < DataBase.buildingsList.Count; i++)
                {
                    if (DataBase.currentBuilding == buildingsList[i].buildingName)
                    {
                        adjustedNumberOfEmployees = buildingsList[i].employeesOwned;
                        buildingInfoEmployees.GetComponent<Text>().text = buildingsList[i].employeesOwned.ToString();
                        buildingInfoEmployeeCap.GetComponent<Text>().text = buildingsList[i].employeeCap.ToString();
                    }
                }
            }

            localCurrentBuilding = DataBase.currentBuilding;
            employeeScreen.SetActive(true);
            buildingName.GetComponent<Text>().text = DataBase.currentBuilding;
            employeeNumber.GetComponent<Text>().text = adjustedNumberOfEmployees.ToString();

            if (addEmployee == true)
            {
                adjustedNumberOfEmployees++;
            }
            if (removeEmployee == true && adjustedNumberOfEmployees > 0)
            {
                adjustedNumberOfEmployees--;
            }
        }
        else if (DataBase.employeeModeIsActivated == false)
        {
            employeeScreen.SetActive(false);
        }

        addEmployee = false;
        removeEmployee = false;
    }

    public void EmployeeModeActivation() //employee mode makes it so that all of your buildings show up as blue and all of the opponent's buildings show
    {                                    //up as red. In this mode, you can adjust # of employees and happiness levels
        if (DataBase.employeeModeIsActivated == false)
        {
            employeeModeButton.GetComponent<Image>().color = new Color32(149, 149, 149, 255); //darken employee button
            buildingName.GetComponent<Text>().text = DataBase.currentBuilding;

            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                if (DataBase.buildingsList[i].owner == "Server" && isServer)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (DataBase.buildingsList[i].owner == "Client" && isServer)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (DataBase.buildingsList[i].owner == "Client" && isClient)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (DataBase.buildingsList[i].owner == "Server" && isClient)
                {
                    GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            DataBase.employeeModeIsActivated = true;

            for (int i = 0; i < DataBase.buildingsList.Count; i++) //display current number of employees the building has in the number that is supposed to be adjusted
            {
                if (DataBase.currentBuilding == buildingsList[i].buildingName)
                {
                    adjustedNumberOfEmployees = buildingsList[i].employeesOwned;
                }
            }
        }

        else if (DataBase.employeeModeIsActivated == true)
        {

            employeeModeButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255); //employee button back to normal

            for (int i = 0; i < DataBase.buildingsList.Count; i++) //turns all of the colors back to normal
            {
                GameObject.Find(DataBase.buildingsList[i].buildingName).GetComponent<SpriteRenderer>().color = Color.white;
            }

            DataBase.employeeModeIsActivated = false;
            DataBase.EmployeeModeHighlightBuildingTest = false;
        }
    }

    public void AddEmployees()
    {
        addEmployee = true;
    }

    public void RemoveEmployees()
    {
        removeEmployee = true;
    }

    public void Confirmed()
    {
        for (int i = 0; i < DataBase.buildingsList.Count; i++)
        {
            if (DataBase.currentBuilding == buildingsList[i].buildingName)
            {
                buildingsList[i].employeesOwned = adjustedNumberOfEmployees;
                DataBase.buildingsList[i].employeesOwned = adjustedNumberOfEmployees; //makes sure the data base has the new info
                buildingInfoEmployees.GetComponent<Text>().text = adjustedNumberOfEmployees.ToString();
            }
        }
    }

    public class Building
    {
        public string buildingName { get; set; }

        public bool buildingBought { get; set; }

        public int buildingPrice { get; set; }

        public string owner { get; set; }

        public int revenue { get; set; }

        public int employeeCap { get; set; }

        public int employeesOwned { get; set; }
    }

}

