using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

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

        for (int c = 0; c < buildingsList.Count; c++) //sends info to database so the PurchaseButton class can see it
        {
            if (buildingsList[c].buildingBought == true)
            {
                DataBase.buildingsList[c].buildingBought = true;
            }
        }

        if (!isServer)
        {
            for (int i = 0; i < buildingsList.Count; i++) //if new purchase shows up in the database, client sends info to the sever
            {
                if (DataBase.buildingsList[i].buildingBought == true && hasAuthority)
                {
                    CmdUpdateBuildingPurchaseOnServer(i);
                }
            }
        }

        if (isServer) {

            for (int ii = 0; ii < buildingsList.Count; ii++) //if new purchase shows up in the database, server sends info to the client
            {
                if (DataBase.buildingsList[ii].buildingBought == true)
                {
                    RpcUpdateBuildingPurchaseOnClient(ii);
                }
            }
        }
	}

    [Command]
    void CmdUpdateBuildingPurchaseOnServer(int building) { //sends command to run on the server
        buildingsList[building].buildingBought = true;
    }

    [ClientRpc]
    void RpcUpdateBuildingPurchaseOnClient(int building) { //sends command to run on the client
        buildingsList[building].buildingBought = true;
    }

    public class Building
    {
        public string buildingName { get; set; }

        public bool buildingBought { get; set; }

        public int buildingPrice { get; set; }
    }
}
