using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Leaderboards : NetworkBehaviour
{
    private int serverBuildingsOwned;
    private int clientBuildingsOwned;

    void Update()
    {
        if (isServer)
        {
            serverBuildingsOwned = 0;

            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                if (DataBase.buildingsList[i].owner == "Server")
                {
                    serverBuildingsOwned++;
                }
            }

            if (serverBuildingsOwned > PlayerPrefs.GetInt("MostBuildingsOwned", 0)) //checks if new record for buildings owned has been reached
            {
                PlayerPrefs.SetInt("MostBuildingsOwned", serverBuildingsOwned);
            }

            if (DataBase.employeesOwned > PlayerPrefs.GetInt("MostEmployeesHired", 0)) { //checks if new record for employees hired has been reached
                PlayerPrefs.SetInt("MostEmployeesHired", DataBase.employeesOwned);
            }

            if (DataBase.totalRevenue > PlayerPrefs.GetInt("MostRevenue", 0)) { //checks if new record for revenue has been reached
                PlayerPrefs.SetInt("MostRevenue", DataBase.totalRevenue);
            }
        }
        else if (!isServer)
        {
            clientBuildingsOwned = 0;

            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                if (DataBase.buildingsList[i].owner == "Client")
                {
                    clientBuildingsOwned++;
                }
            }

            if (clientBuildingsOwned > PlayerPrefs.GetInt("MostBuildingsOwned", 0))
            {
                PlayerPrefs.SetInt("MostBuildingsOwned", clientBuildingsOwned);
            }

            if (DataBase.employeesOwned > PlayerPrefs.GetInt("MostEmployeesHired", 0)) { //checks if new record for employees hired has been reached
                PlayerPrefs.SetInt("MostEmployeesHired", DataBase.employeesOwned);
            }

            if (DataBase.totalRevenue > PlayerPrefs.GetInt("MostRevenue", 0)) { //checks if new record for revenue has been reached
                PlayerPrefs.SetInt("MostRevenue", DataBase.totalRevenue);
            }
        }
    }
}
