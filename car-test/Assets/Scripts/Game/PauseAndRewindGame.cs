using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseAndRewindGame : MonoBehaviour
{
    private bool isRewinding = false;

    List<Vector3> positions;
    List<Quaternion> rotations;

    public Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {   // Get positions and 
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            startRewind();
        }

        if (Input.GetKeyUp(KeyCode.R)) 
        {
            stopRewind();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        Debug.Log(positions.Count);
    }

    void FixedUpdate()
    {
        if(isRewinding)
        {
            rewind();
        }
        else
        {
            recordPosition();
        }

    }

    void rewind()
    {   // If there are positions and rotations stored transform the car to the first element of the list
        if (positions.Count > 0 && rotations.Count > 0)
        {   
        
            transform.position = positions[0];
            positions.RemoveAt(0);
            transform.rotation = rotations[0];
            rotations.RemoveAt(0);
        }
        // Otherwise stop rewind
        else
        {
            stopRewind();
        }
        
    }

    void recordPosition()
    {
        positions.Insert(0, transform.position);
        rotations.Insert(0, transform.rotation);
        

        // If positions contain more than 3600 elements (1 minute of recording), then remove the first recorded position and rotation
        if (positions.Count > 3600)
        {
            positions.RemoveAt(positions.Count - 1);
            rotations.RemoveAt(rotations.Count - 1);
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0;
    }

    void resumeGame()
    {
        Time.timeScale = 1;
    }

    public void startRewind()
    {
        Time.timeScale = 2;
        isRewinding = true;
        rb.isKinematic = true;
        
    }

    public void stopRewind()
    {
        Time.timeScale = 1;
        isRewinding = false;
        rb.isKinematic = false;
    }
}
