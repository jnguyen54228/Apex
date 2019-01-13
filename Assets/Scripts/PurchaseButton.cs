using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PurchaseButton : NetworkBehaviour //Class that manages the purchase status of each building
{
    public GameObject cashText;
    public GameObject totalRevenueText;
    public GameObject purchaseButton;
    public GameObject purchaseButtonText;

    IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building 1", buildingBought = false, buildingPrice = 20, owner = "none", revenue = 10},
        new Building(){ buildingName = "Office Building 2", buildingBought = false, buildingPrice = 20, owner = "none", revenue = 10},
        new Building(){ buildingName = "Convenience Store 1", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15},
        new Building(){ buildingName = "Convenience Store 2", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 70, owner = "none", revenue = 35},
        new Building(){ buildingName = "Club", buildingBought = false, buildingPrice = 100, owner = "none", revenue = 50},
        new Building(){ buildingName = "Super Market", buildingBought = false, buildingPrice = 50, owner = "none", revenue = 25},
        new Building(){ buildingName = "Church", buildingBought = false, buildingPrice = 30, owner = "none", revenue = 15},
        new Building(){ buildingName = "Movie Theater", buildingBought = false, buildingPrice = 60, owner = "none", revenue = 30}
    };

    // Use this for initialization
    void Start() {
        purchaseButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        cashText.GetComponent<Text>().text = "$" + DataBase.cash.ToString();
        totalRevenueText.GetComponent<Text>().text = "$" + DataBase.totalRevenue.ToString();

        for (int i = 0; i < buildingsList.Count; i++) { //checks database to see if the building has been bought from the other computer
            if (DataBase.buildingsList[i].buildingBought == true) {
                buildingsList[i].buildingBought = true;
            }
        }

        for (int c = 0; c < buildingsList.Count; c++) { //if the clicked on building is purchased, the option to purchase it is disabled
            if (DataBase.currentBuilding == buildingsList[c].buildingName && buildingsList[c].buildingBought == true) {
                purchaseButton.GetComponent<Button>().interactable = false;
                purchaseButton.GetComponent<Image>().color = Color.gray;
                purchaseButtonText.GetComponent<Text>().text = DataBase.buildingsList[c].owner; //displays name of owner of the building
            }
            else if(DataBase.currentBuilding == buildingsList[c].buildingName && buildingsList[c].buildingBought == false)
            {
                purchaseButton.GetComponent<Button>().interactable = true;
                purchaseButton.GetComponent<Image>().color = Color.white;
                purchaseButtonText.GetComponent<Text>().text = "Purchase";
            }
        }
    }

    public void PurchaseBuilding()
    {
        if (DataBase.cash >= DataBase.currentBuildingPrice) //if the player has enough money to purchse the building
        {
            DataBase.cash -= DataBase.currentBuildingPrice;
            cashText.GetComponent<Text>().text = "$" + DataBase.cash.ToString();

            for (int ii = 0; ii < buildingsList.Count; ii++) {
                if (DataBase.currentBuilding == buildingsList[ii].buildingName) {
                    DataBase.buildingsList[ii].buildingBought = true; //tells database that the building is purchased so that
                    buildingsList[ii].buildingBought = true;          //the player controller can send it to the other computers database

                    DataBase.totalRevenue += buildingsList[ii].revenue;
                    totalRevenueText.GetComponent<Text>().text = "$" + DataBase.totalRevenue.ToString();

                    if (isServer)
                    {
                        DataBase.serverBuildingPurchased = true;

                        DataBase.buildingsList[ii].owner = "Server";
                        buildingsList[ii].owner = "Server";
                    }
                    else if (!isServer) {
                        DataBase.clientBuildingPurchased = true;

                        DataBase.buildingsList[ii].owner = "Client";
                        buildingsList[ii].owner = "Client";
                    }
                }
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
    }
}
