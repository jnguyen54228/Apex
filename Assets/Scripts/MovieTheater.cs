using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieTheater : MonoBehaviour
{

    public GameObject moviePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMoviePanel() {
        moviePanel.SetActive(true);
    }

    public void CloseMoviePanel() {
        moviePanel.SetActive(false);
    }
}
