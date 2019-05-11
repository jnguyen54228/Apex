using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PurchaseScreen : NetworkBehaviour //Class used for displaying the building purchase screen
{
    public GameObject purchaseScreen;
    public GameObject buildingName;
    public GameObject buildingImage;
    public GameObject buildingPrice;
    public GameObject buildingRevenue;

    public GameObject easterEgg;
    public GameObject moviePanel;


    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Office Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Office Building 3", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Convenience Store 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Convenience Store 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Convenience Store 3", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Apartment Building 3", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35, employeeCap = 15, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 35, leaveRate = 5},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35, employeeCap = 15, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 35, leaveRate = 5},
        new Building(){ buildingName = "Club 1", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 5},
        new Building(){ buildingName = "Club 2", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 5},
        new Building(){ buildingName = "Super Market 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Super Market 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Church 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Church 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Movie Theater", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Blockbuster 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Blockbuster 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "S-Bank", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 5},
        new Building(){ buildingName = "Cake Shop 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Cake Shop 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Post Office 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Post Office 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15, employeeCap = 5, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 15, leaveRate = 5},
        new Building(){ buildingName = "Mall", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 5},
        new Building(){ buildingName = "H-Tower", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50, employeeCap = 20, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 50, leaveRate = 5},
        new Building(){ buildingName = "Parking Garage 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5},
        new Building(){ buildingName = "Parking Garage 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25, employeeCap = 10, employeesOwned = 0, daysWithNoEmployees = 0, baseRevenue = 25, leaveRate = 5}
    };

    // Update is called once per frame
    void Update()
    {
        if (purchaseScreen.activeInHierarchy == false && DataBase.previousBuilding != null && DataBase.employeeModeIsActivated == true) {
            DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = DataBase.employeeModePreviousColor;
        }
        else if (purchaseScreen.activeInHierarchy == false && DataBase.previousBuilding != null && DataBase.employeeModeIsActivated == false) {
            DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnMouseDown()
    {
        DataBase.currentBuildingObject = gameObject;

        if (DataBase.employeeModeIsActivated == true) //for situations where a building needs to back to red/blue after being highlighted yellow
        {
            if (DataBase.previousBuilding != null)
            {
                if (DataBase.previousBuilding.GetComponent<SpriteRenderer>().color == Color.yellow)
                {
                    DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

            if (DataBase.EmployeeModeHighlightBuildingTest == true) {

                DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = DataBase.employeeModePreviousColor;
            }

            DataBase.employeeModePreviousColor = gameObject.GetComponent<SpriteRenderer>().color;

            DataBase.EmployeeModeHighlightBuildingTest = true; //goes back to false when employee mode is deativated in EmployeeMode.cs script
        }
        else if(DataBase.highlightBuildingTest == true)
        {
            DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = Color.white; //change the color of the building that was 
                                                                                            //just clicked off of back to white
        }

        for (int i = 0; i < buildingsList.Count; i++)
            {  //finds that building that is clicked on and adds its values to the purchase screen
                if (gameObject.name == buildingsList[i].buildingName)
                {
                    if (DataBase.buildingsList[i].buildingBought == true)
                    {
                        if (DataBase.buildingsList[i].buildingName == "Movie Theater")
                        {
                            easterEgg.SetActive(true);
                        }
                    }
                    else
                    {
                    easterEgg.SetActive(false);

                    }

                    buildingPrice.GetComponent<Text>().text = "$" + buildingsList[i].buildingPrice;
                    buildingRevenue.GetComponent<Text>().text = "$" + buildingsList[i].revenue;
                    DataBase.currentBuildingPrice = buildingsList[i].buildingPrice;
                    DataBase.currentBuilding = gameObject.name;
                }
            }

            buildingName.GetComponent<Text>().text = gameObject.name;
            buildingImage.GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            purchaseScreen.SetActive(true);
            DataBase.highlightBuildingTest = true;
            DataBase.previousBuilding = gameObject;
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

        public int daysWithNoEmployees { get; set; }

        public int baseRevenue { get; set; }

        public int leaveRate { get; set; }
    }
}
