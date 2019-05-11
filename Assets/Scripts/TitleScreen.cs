using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public GameObject mostBuildingsOwned;
    public GameObject mostEmployeesHired;
    public GameObject mostRevenue;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Network");
    }
    public void OptionsButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void OpenLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        mostBuildingsOwned.GetComponent<Text>().text = PlayerPrefs.GetInt("MostBuildingsOwned", 0).ToString();
        mostEmployeesHired.GetComponent<Text>().text = PlayerPrefs.GetInt("MostEmployeesHired", 0).ToString();
        mostRevenue.GetComponent<Text>().text = PlayerPrefs.GetInt("MostRevenue", 0).ToString();
    }
    public void ResetStats() {
        PlayerPrefs.DeleteAll();
        mostBuildingsOwned.GetComponent<Text>().text = PlayerPrefs.GetInt("MostBuildingsOwned", 0).ToString();
        mostEmployeesHired.GetComponent<Text>().text = PlayerPrefs.GetInt("MostEmployeesHired", 0).ToString();
        mostRevenue.GetComponent<Text>().text = PlayerPrefs.GetInt("MostRevenue", 0).ToString();
    }
}
