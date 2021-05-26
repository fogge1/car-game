using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCarScript : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    
    // Set a playerpref to the selected car and store it to load it in the map scene
    void OnMouseDown()
    {   
        PlayerPrefs.SetString("selectedCar", gameObject.name);
        Debug.Log(PlayerPrefs.GetString("selectedCar"));
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
