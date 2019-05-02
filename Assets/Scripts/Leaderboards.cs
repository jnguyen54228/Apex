using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Leaderboards : NetworkBehaviour
{
    private int serverBuildingsOwned;
    private int clientBuildingsOwned;

    public GameObject leaderboardPanel;
    public GameObject mostBuildingsOwned;
    public GameObject mostEmployeesHired;
    public GameObject mostRevenue;

    void Update()
    {
        if (isServer)
        {
            for (int i = 0; i < DataBase.buildingsList.Count; i++)
            {
                if (DataBase.buildingsList[i].owner == "Server") {
                    serverBuildingsOwned++;
                }
            }

            if (serverBuildingsOwned > PlayerPrefs.GetInt("MostBuildingsOwned", 0)) {
                PlayerPrefs.SetInt("MostBuildingsOwned", serverBuildingsOwned);
                mostBuildingsOwned.GetComponent<Text>().text = PlayerPrefs.GetInt("MostBuildingsOwned", 0).ToString();
            }
        }
        else if (!isServer)
        {
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
                mostBuildingsOwned.GetComponent<Text>().text = PlayerPrefs.GetInt("MostBuildingsOwned", 0).ToString();
            }
        }
    }

    public void OpenLeaderboard() {
        leaderboardPanel.SetActive(true);
    }
}
