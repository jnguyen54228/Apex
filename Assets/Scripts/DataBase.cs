using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBase : MonoBehaviour {

    public static int cash = 100;
    public static int currentBuildingPrice;
    public static string currentBuilding;
    public static bool highlightBuildingTest = false;
    public static GameObject previousBuilding;

    public static bool officeBought = false;
    public static bool convienienceStoreBought = false;
    public static bool apartmentBuilding1Bought = false;
    public static bool apartmentBuilding2Bought = false;
    public static bool tradeCenter1Bought = false;
    public static bool tradeCenter2Bought = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
