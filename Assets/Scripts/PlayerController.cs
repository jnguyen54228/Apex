using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    private bool officeBought = false;
    private bool convienienceStoreBought = false;
    private bool apartmentBuilding1Bought = false;
    private bool apartmentBuilding2Bought = false;
    private bool tradeCenter1Bought = false;
    private bool tradeCenter2Bought = false;

    IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building", buildingBought = false, buildingPrice = 20},
        new Building(){ buildingName = "Convienience Store", buildingBought = false, buildingPrice = 30},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 75},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 75}
    };

    void Start () {
		
	}
	
	void Update () {
        /*if (DataBase.officeBought == true && !isServer && hasAuthority) {
            CmdUpdateBuildingPurchase("office"); 
        }
        if (DataBase.convienienceStoreBought == true && !isServer && hasAuthority) {
            CmdUpdateBuildingPurchase("convienence store");
        }
        if (DataBase.apartmentBuilding1Bought == true && !isServer && hasAuthority)
        {
            CmdUpdateBuildingPurchase("apartment 1");
        }
        if (DataBase.apartmentBuilding2Bought == true && !isServer && hasAuthority)
        {
            CmdUpdateBuildingPurchase("apartment 2");
        }
        if (DataBase.tradeCenter1Bought == true && !isServer && hasAuthority)
        {
            CmdUpdateBuildingPurchase("trade center 1");
        }
        if (DataBase.tradeCenter2Bought == true && !isServer && hasAuthority)
        {
            CmdUpdateBuildingPurchase("trade center 2");
        }*/

        for (int c = 0; c < buildingsList.Count; c++)
        {
            if (buildingsList[c].buildingBought == true)
            {
                DataBase.buildingsList[c].buildingBought = true;
            }
        }

        for (int i = 0; i < buildingsList.Count; i++) {
            if (DataBase.buildingsList[i].buildingBought == true && !isServer && hasAuthority) {
                CmdUpdateBuildingPurchaseOnServer(i);
            }
        }

        if (isServer) {
            /*if(officeBought == true) {
                DataBase.officeBought = true;
            }
            if (convienienceStoreBought == true)
            {
                DataBase.convienienceStoreBought = true;
            }
            if (apartmentBuilding1Bought == true)
            {
                DataBase.apartmentBuilding1Bought = true;
            }
            if (apartmentBuilding2Bought == true)
            {
                DataBase.apartmentBuilding2Bought = true;
            }
            if (tradeCenter1Bought == true)
            {
                DataBase.tradeCenter1Bought = true;
            }
            if (tradeCenter2Bought == true)
            {
                DataBase.tradeCenter2Bought = true;
            }*/

            for (int ii = 0; ii < buildingsList.Count; ii++)
            {
                if (DataBase.buildingsList[ii].buildingBought == true)
                {
                    RpcUpdateBuildingPurchaseOnClient(ii);
                }
            }
        }
	}

    [Command]
    void CmdUpdateBuildingPurchaseOnServer(int building) {
        /*if (building == "office")
        {
            officeBought = true;
        }
        else if (building == "convienence store") {
            convienienceStoreBought = true;
        }
        else if (building == "apartment 1")
        {
            apartmentBuilding1Bought = true;
        }
        else if (building == "apartment 2")
        {
            apartmentBuilding2Bought= true;
        }
        else if (building == "trade center 1")
        {
            tradeCenter1Bought = true;
        }
        else if (building == "trade center 2")
        {
            tradeCenter2Bought = true;
        }*/

        buildingsList[building].buildingBought = true;
    }

    [ClientRpc]
    void RpcUpdateBuildingPurchaseOnClient(int building) {
        buildingsList[building].buildingBought = true;
    }

    public class Building
    {
        public string buildingName { get; set; }

        public bool buildingBought { get; set; }

        public int buildingPrice { get; set; }
    }
}
