using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class DataBase : MonoBehaviour {     //Class used for data shared across the game

    public static int cash = 100;
    public int Cash = cash;
    //private static int Cash;
    public static int currentBuildingPrice;
    public static string currentBuilding;
    public static bool highlightBuildingTest = false;
    public static GameObject previousBuilding;
    public static string turn = "server"; //the server gets the first turn of the game
    public static bool serverTurnEnded = false;
    public static bool clientTurnEnded = false;
    public static int[,] ownedBuildingTypes = new int[4, 2] { { 0, 20 }, { 0, 30 }, { 0, 50 }, { 0, 75 } };

    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building", buildingBought = false, buildingPrice = 20},
        new Building(){ buildingName = "Convienience Store", buildingBought = false, buildingPrice = 30},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 75},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 75}
    };

    
    public int Main()
    {
        for (int i = 0; i < 4; i++)
        {
            Cash = cash + (ownedBuildingTypes[i, 0] * ownedBuildingTypes[i, 1]);
        }
        return Cash;
    }


    public class Building
    {
         public string buildingName { get; set; }

         public bool buildingBought { get; set; }

         public int buildingPrice { get; set; }
    }
}

