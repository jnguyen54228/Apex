using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace System;

public class Player : MonoBehaviour
{

    private static int Cash = DataBase.cash;
    public static int[,] ownedBuildingTypes = new int[,] { { 0, 20 }, { 0, 30 }, { 0, 50 }, { 0, 75 } };
    // '0' - #number'o'Office ($20), '1' - #number'o'convienienceStore ($30), 
    // '2' - #number'o'apartmentBuilding ($50), '3' - #number'o'tradeCenter ($75)

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If building type owned gain x money per building pe


    }

    
    public static IList<Building> buildingsList = new List<Building>() {

        new Building(){ buildingName = "Office Building", buildingBought = false, buildingPrice = 20},
        new Building(){ buildingName = "Convienience Store", buildingBought = false, buildingPrice = 30},
        new Building(){ buildingName = "Apartment Building 1", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Apartment Building 2", buildingBought = false, buildingPrice = 50},
        new Building(){ buildingName = "Trade Center 1", buildingBought = false, buildingPrice = 75},
        new Building(){ buildingName = "Trade Center 2", buildingBought = false, buildingPrice = 75}
    };

    

    //per turn
    
    for(int i = 0; i < 4; i++)
    {
        Cash += ownedBuildingTypes[i,0] * ownedBuildingTypes[i,1];
`   }
}