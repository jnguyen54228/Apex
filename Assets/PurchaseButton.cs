using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PurchaseButton : NetworkBehaviour
{

    public GameObject cashText;
    public GameObject purchaseButton;
    public GameObject purchaseButtonText;


    [SyncVar]
    private bool officeBought = false;
    [SyncVar]
    private bool convienienceStoreBought = false;
    [SyncVar]
    private bool apartmentBuilding1Bought = false;
    [SyncVar]
    private bool apartmentBuilding2Bought = false;
    [SyncVar]
    private bool tradeCenter1Bought = false;
    [SyncVar]
    private bool tradeCenter2Bought = false;

    // Use this for initialization
    void Start()
    {
        purchaseButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DataBase.currentBuilding == "Office Building" && officeBought == true)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            purchaseButton.GetComponent<Image>().color = Color.gray;
            purchaseButtonText.GetComponent<Text>().text = "SOLD";
        }
        else if (DataBase.currentBuilding == "Convienience Store" && convienienceStoreBought == true)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            purchaseButton.GetComponent<Image>().color = Color.gray;
            purchaseButtonText.GetComponent<Text>().text = "SOLD";
        }
        else if (DataBase.currentBuilding == "Apartment Building 1" && apartmentBuilding1Bought == true)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            purchaseButton.GetComponent<Image>().color = Color.gray;
            purchaseButtonText.GetComponent<Text>().text = "SOLD";
        }
        else if (DataBase.currentBuilding == "Apartment Building 2" && apartmentBuilding2Bought == true)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            purchaseButton.GetComponent<Image>().color = Color.gray;
            purchaseButtonText.GetComponent<Text>().text = "SOLD";
        }
        else if (DataBase.currentBuilding == "Trade Center 1" && tradeCenter1Bought == true)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            purchaseButton.GetComponent<Image>().color = Color.gray;
            purchaseButtonText.GetComponent<Text>().text = "SOLD";
        }
        else if (DataBase.currentBuilding == "Trade Center 2" && tradeCenter2Bought == true)
        {
            purchaseButton.GetComponent<Button>().interactable = false;
            purchaseButton.GetComponent<Image>().color = Color.gray;
            purchaseButtonText.GetComponent<Text>().text = "SOLD";
        }
        else
        {
            purchaseButton.GetComponent<Button>().interactable = true;
            purchaseButton.GetComponent<Image>().color = Color.white;
            purchaseButtonText.GetComponent<Text>().text = "Purchase";
        }
    }

    public void PurchaseBuilding()
    {
        if (DataBase.cash >= DataBase.currentBuildingPrice)
        {
            DataBase.cash -= DataBase.currentBuildingPrice;
            cashText.GetComponent<Text>().text = DataBase.cash.ToString();

            if(DataBase.currentBuilding == "Office Building")
            {
                DataBase.officeBought = true;
                officeBought = true;
            }
            else if(DataBase.currentBuilding == "Convienience Store")
            {
                DataBase.convienienceStoreBought = true;
                convienienceStoreBought = true;
            }
            else if (DataBase.currentBuilding == "Apartment Building 1")
            {
                DataBase.apartmentBuilding1Bought = true;
                apartmentBuilding1Bought = true;
            }
            else if (DataBase.currentBuilding == "Apartment Building 2")
            {
                DataBase.apartmentBuilding2Bought = true;
                apartmentBuilding2Bought = true;
            }
            else if (DataBase.currentBuilding == "Trade Center 1")
            {
                DataBase.tradeCenter1Bought = true;
                tradeCenter1Bought = true;
            }
            else if (DataBase.currentBuilding == "Trade Center 2")
            {
                DataBase.tradeCenter2Bought = true;
                tradeCenter2Bought = true;
            }
        }
    }
}
