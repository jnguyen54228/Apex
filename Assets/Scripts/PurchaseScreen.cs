using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseScreen : MonoBehaviour
{

    public GameObject purchaseScreen;
    public GameObject buildingName;
    public GameObject buildingImage;
    public GameObject buildingPrice;

    IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building", buildingBought = false, buildingPrice = 20},
        new Building(){ buildingName = "Convienience Store", buildingBought = false, buildingPrice = 30},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 75},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 75}
    };

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (DataBase.highlightBuildingTest == true)
        {
            DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = Color.white;
        }

        /*if (gameObject.name == "Office Building")
        {
            buildingPrice.GetComponent<Text>().text = "$" + officeBuildingPrice;
            DataBase.currentBuildingPrice = officeBuildingPrice;
            DataBase.currentBuilding = gameObject.name;
        }
        else if (gameObject.name == "Convienience Store")
        {
            buildingPrice.GetComponent<Text>().text = "$" + convienienceStorePrice;
            DataBase.currentBuildingPrice = convienienceStorePrice;
            DataBase.currentBuilding = gameObject.name;
        }
        else if (gameObject.name == "Apartment Building 1" || gameObject.name == "Apartment Building 2")
        {
            buildingPrice.GetComponent<Text>().text = "$" + apartmentBuildingPrice;
            DataBase.currentBuildingPrice = apartmentBuildingPrice;
            DataBase.currentBuilding = gameObject.name;
        }
        else if (gameObject.name == "Trade Center 1" || gameObject.name == "Trade Center 2")
        {
            buildingPrice.GetComponent<Text>().text = "$" + tradeCenterPrice;
            DataBase.currentBuildingPrice = tradeCenterPrice;
            DataBase.currentBuilding = gameObject.name;
        }*/

        for (int i = 0; i < buildingsList.Count; i++) {
            if (gameObject.name == buildingsList[i].buildingName) {
                buildingPrice.GetComponent<Text>().text = "$" + buildingsList[i].buildingPrice;
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
    }
}
