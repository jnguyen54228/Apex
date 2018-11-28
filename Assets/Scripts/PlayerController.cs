using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (DataBase.officeBought == true && !isServer && hasAuthority) {

            CmdUpdateBuildingPurchase(DataBase.officeBought);
            
        }
	}

    [Command]
    void CmdUpdateBuildingPurchase(bool building) {
        building = true;
        Debug.Log("test");
    }
}
