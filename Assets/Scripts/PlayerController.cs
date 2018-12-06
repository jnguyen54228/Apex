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

    void Start () {
		
	}
	
	void Update () {
        if (DataBase.officeBought == true && !isServer && hasAuthority) {
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
        }

        if (isServer) {
            if(officeBought == true) {
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
            }
        }
	}

    [Command]
    void CmdUpdateBuildingPurchase(string building) {
        if (building == "office")
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
        }
    }
}
