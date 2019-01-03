using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataBase : MonoBehaviour {     //Class used for data shared across the game

    public static int cash = 100;
    public static int currentBuildingPrice;
    public static string currentBuilding;
    public static bool highlightBuildingTest = false;
    public static GameObject previousBuilding;
    public static string turn = "server"; //the server gets the first turn of the game
    public static bool serverTurnEnded = false;
    public static bool clientTurnEnded = false;

    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building", buildingBought = false, buildingPrice = 20, owner = "none"},
        new Building(){ buildingName = "Convienience Store", buildingBought = false, buildingPrice = 30, owner = "none"},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50, owner = "none"},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50, owner = "none"},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 75, owner = "none"},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 75, owner = "none"}
    };

    public class Building
    {
        public string buildingName { get; set; }

        public bool buildingBought { get; set; }

        public int buildingPrice { get; set; }

        public string owner { get; set; }
    }
}
