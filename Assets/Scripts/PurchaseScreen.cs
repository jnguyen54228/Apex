using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseScreen : MonoBehaviour //Class used for displaying the building purchase screen
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
            DataBase.previousBuilding.GetComponent<SpriteRenderer>().color = Color.white; //change the color of the building that was 
        }                                                                                 //just clicked off of back to white

        for (int i = 0; i < buildingsList.Count; i++) {  //finds that building that is clicked on and adds its values to the purchase screen
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
