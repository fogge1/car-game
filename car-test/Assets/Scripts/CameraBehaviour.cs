using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject car;
    public bool pov = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {   if (pov == true)
            {
                gameObject.transform.position = new Vector3(car.transform.position.x + -0.237f, car.transform.position.y + 0.857f, car.transform.position.z + 0.008f);
                pov = false;
                Debug.Log("Test0");
            }
            if (pov==false)
            {
                gameObject.transform.position = new Vector3(car.transform.position.x, 1.51f, -4.76f);
                pov = true;
                Debug.Log("Test1");
            }
        }
    }
}
