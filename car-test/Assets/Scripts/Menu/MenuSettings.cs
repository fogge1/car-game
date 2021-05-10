using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuSettings : MonoBehaviour
{
    // Start is called before the first frame update

    public void playGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("selectedMap")); // Load game scene
    }

    public void selectMap()
    {
        SceneManager.LoadScene(5);
    }

    public void SelectCar()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
