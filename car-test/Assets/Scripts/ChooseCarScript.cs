using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChooseCarScript : MonoBehaviour
{
    public GameObject car;
    // Start is called before the first frame update
    
    void OnMouseDown()
    {
        Instantiate(car, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
