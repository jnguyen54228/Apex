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
    public GameObject buildingInfo;
    public GameObject employeeCapText;
    public GameObject employeesOwnedText;


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

    // Use this for initialization
    void Start()
    {
        buildingInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Purchase Screen").activeInHierarchy == false) {
            DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnMouseDown()
    {
        if (DataBase.employeeModeIsActivated == true) //for situations where a building needs to back to red/blue after being highlighted yellow
        {
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
                        employeeCapText.GetComponent<Text>().text = (DataBase.buildingsList[i].employeeCap).ToString();
                        employeesOwnedText.GetComponent<Text>().text = (DataBase.buildingsList[i].employeesOwned).ToString();
                        buildingInfo.SetActive(true);
                    }
                    else
                    {
                        buildingInfo.SetActive(false);
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
    }
}
