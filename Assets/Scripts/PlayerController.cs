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

            CmdUpdateBuildingPurchase(officeBought);
            
        }

        if (isServer) {

            if(officeBought == true) {
                DataBase.officeBought = true;
            }
        }
	}

    [Command]
    void CmdUpdateBuildingPurchase(bool building) {
        building = true;
    }
}
