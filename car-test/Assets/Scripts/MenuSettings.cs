using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Text amountCoins;
    public Text motorForce;
    public Text getMoreCoins;

    public void playGame()
    {
        SceneManager.LoadScene(1); // Load game scene
    }

    public void upgradeMotorForce()
    {   
        if (PlayerPrefs.GetInt("coins") > 0)
        {
            PlayerPrefs.SetFloat("motorForce", PlayerPrefs.GetFloat("motorForce") + 50);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 1);
        } 
        else
        {
            getMoreCoins.text = "Get more coins you nub";
        }
  
    }

    public void resetMotorForce()
    {
        PlayerPrefs.SetFloat("motorForce", 50);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        amountCoins.text = PlayerPrefs.GetInt("coins").ToString();
        motorForce.text = "MotorForce: " + PlayerPrefs.GetFloat("motorForce").ToString();
    }
}
