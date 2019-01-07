using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building", buildingBought = false, buildingPrice = 20, owner = "none"},
        new Building(){ buildingName = "Convienience Store", buildingBought = false, buildingPrice = 30, owner = "none"},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none"},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none"},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 75, owner = "none"},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 75, owner = "none"}
    };

    void Start () {
	}
	
	void Update () {

        if (DataBase.serverTurnEnded == true && hasAuthority) //if the end turn button has been pressed...
        {
            RpcUpdateTurnOnClient();
            DataBase.serverTurnEnded = false;
        }
        else if (DataBase.clientTurnEnded == true && hasAuthority)
        {
            CmdUpdateTurnOnServer();
            DataBase.clientTurnEnded = false;
        }

        /*for (int c = 0; c < buildingsList.Count; c++) //sends info to database so the PurchaseButton class can see it
        {
            if (buildingsList[c].buildingBought == true)
            {
                DataBase.buildingsList[c].buildingBought = true;
            }
        }*/

        if (DataBase.serverBuildingPurchased == true)
        {
            for (int ii = 0; ii < buildingsList.Count; ii++) //if new purchase shows up in the database that isn't recognized locally, server sends info to the client
            {
                if (DataBase.buildingsList[ii].buildingBought == true && buildingsList[ii].buildingBought == false && DataBase.buildingsList[ii].owner != "client" && hasAuthority)
                {
                    RpcUpdateBuildingPurchaseOnClient(ii);
                    DataBase.serverBuildingPurchased = false;
                }
            }
        }

        if (DataBase.clientBuildingPurchased == true)
        {
            for (int i = 0; i < buildingsList.Count; i++) //if new purchase shows up in the database that isn't recognized locally, client sends info to the sever
            {
                if (DataBase.buildingsList[i].buildingBought == true && buildingsList[i].buildingBought == false && DataBase.buildingsList[i].owner != "server" && hasAuthority)
                {
                    CmdUpdateBuildingPurchaseOnServer(i);
                    DataBase.clientBuildingPurchased = false;
                }
            }
        }
	}

    [Command]
    void CmdUpdateBuildingPurchaseOnServer(int building) { //sends command to run on the server that says that a specific building has been baught
        DataBase.buildingsList[building].buildingBought = true;
        DataBase.buildingsList[building].owner = "Client";

        buildingsList[building].buildingBought = true;
        buildingsList[building].owner = "Client";
    }

    [ClientRpc]
    void RpcUpdateBuildingPurchaseOnClient(int building) { //sends command to run on the client
        DataBase.buildingsList[building].buildingBought = true;
        DataBase.buildingsList[building].owner = "Server";

        buildingsList[building].buildingBought = true;
        buildingsList[building].owner = "Server";
    }

    [Command]
    void CmdUpdateTurnOnServer() {
        DataBase.turn = "server";
    }

    [ClientRpc]
    void RpcUpdateTurnOnClient()
    {
        DataBase.turn = "client";
    }

    public class Building
    {
        public string buildingName { get; set; }

        public bool buildingBought { get; set; }

        public int buildingPrice { get; set; }

        public string owner { get; set; }
    }
}
