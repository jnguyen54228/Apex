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
    public GameObject plusAndMinus;
    public GameObject confirm;
    public bool addEmp;
    public bool removeEmp;
    public int pM = 0;

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
            employeeScreen.SetActive(true);
            buildingName.GetComponent<Text>().text = DataBase.currentBuilding;
            plusAndMinus.GetComponent<Text>().text = pM.ToString();
            if (addEmp == true)
            {
                pM++;
            }
            if (removeEmp == true && pM > 0)
            {
                pM--;
            }
        }
        else if (DataBase.employeeModeIsActivated == false)
        {
            employeeScreen.SetActive(false);
        }

        addEmp = false;
        removeEmp = false;
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
        addEmp = true;
    }

    public void RemoveEmployees()
    {
        removeEmp = true;
    }

    public void Confirmed()
    {
        for (int i = 0; i < DataBase.buildingsList.Count; i++)
        {
            if (DataBase.currentBuilding == buildingsList[i].buildingName)
            {
                buildingsList[i].employeesOwned = pM;
            }
        }
        pM = 0;
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

