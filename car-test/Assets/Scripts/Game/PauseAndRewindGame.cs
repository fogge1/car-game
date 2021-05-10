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
    {
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
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }

        if (Input.GetKeyUp(KeyCode.R)) 
        {
            StopRewind();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }

    }

    void Rewind()
    {   
        if (positions.Count > 0 && rotations.Count > 0)
        {   
        
            transform.position = positions[0];
            positions.RemoveAt(0);
            transform.rotation = rotations[0];
            rotations.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
        
    }

    void Record()
    {
        positions.Insert(0, transform.position);
        rotations.Insert(0, transform.rotation);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void StartRewind()
    {
        Time.timeScale = 2;
        isRewinding = true;
        rb.isKinematic = true;
        
    }

    public void StopRewind()
    {
        Time.timeScale = 1;
        isRewinding = false;
        rb.isKinematic = false;
    }
}
