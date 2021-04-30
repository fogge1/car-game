using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCarScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject yellowcar;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "DriftMap")
        {   
            if (PlayerPrefs.GetString("selectedCar") == "racecaryellow")
            {
                Instantiate(yellowcar, new Vector3(245, 4, 217), Quaternion.identity);
            }
        }
        else if (SceneManager.GetActiveScene().name == "SprintMap") {

            if (PlayerPrefs.GetString("selectedCar") == "racecaryellow")
            {
                Instantiate(yellowcar, new Vector3(958, 225, 922), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
