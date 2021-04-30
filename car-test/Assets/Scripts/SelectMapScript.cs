using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMapScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SelectDriftMap()
    {
        PlayerPrefs.SetInt("selectedMap", 3);
        SceneManager.LoadScene(0);
    }

    public void SelectModularMap()
    {
        PlayerPrefs.SetInt("selectedMap", 2);
        SceneManager.LoadScene(0);
    }

    public void SelectSprintMap()
    {
        PlayerPrefs.SetInt("selectedMap", 4);
        SceneManager.LoadScene(0);
    }

   
}
