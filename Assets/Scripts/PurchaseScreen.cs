using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseScreen : MonoBehaviour {

    public GameObject purchaseScreen;
    public GameObject buildingName;
    public GameObject buildingImage;
    public GameObject buildingPrice;

    private int officeBuildingPrice = 20;
    private int convienienceStorePrice = 30;
    private int apartmentBuildingPrice = 50;
    private int tradeCenterPrice = 75;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if(gameObject.name == "Office Building")
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
        else if(gameObject.name == "Trade Center 1" || gameObject.name == "Trade Center 2")
        {
            buildingPrice.GetComponent<Text>().text = "$" + tradeCenterPrice;
            DataBase.currentBuildingPrice = tradeCenterPrice;
            DataBase.currentBuilding = gameObject.name;
        }
        buildingName.GetComponent<Text>().text = gameObject.name;
        buildingImage.GetComponent<Image>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        purchaseScreen.SetActive(true);
    }
}
