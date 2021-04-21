using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarMovement : MonoBehaviour
{

    public float MotorForce, SteerForce, BreakForce, friction;
    public WheelCollider wheelfrontleft, wheelfrontrightSphere, wheelbackleft, wheelbackright;
    public GameObject car;

    [SerializeField] TextMeshProUGUI speedometer;
    private double Speed;
    private Vector3 startingPosition, speedvec;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {

        float v = Input.GetAxis("Vertical") * MotorForce;


        wheelbackleft.motorTorque = v;
        wheelbackright.motorTorque = v;

        car.transform.Rotate(Vector3.up * SteerForce * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);

        if (Input.GetKey(KeyCode.Space))
        {
            wheelbackleft.brakeTorque = BreakForce;
            wheelbackright.brakeTorque = BreakForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            wheelbackleft.brakeTorque = 0;
            wheelbackright.brakeTorque = 0;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            if (wheelbackleft.brakeTorque <= BreakForce && wheelbackright.brakeTorque <= BreakForce)
            {
                wheelbackleft.brakeTorque += friction * Time.deltaTime * BreakForce;
                wheelbackright.brakeTorque += friction * Time.deltaTime * BreakForce;
            }
            else
            {
                wheelbackleft.brakeTorque = BreakForce;
                wheelbackright.brakeTorque = BreakForce;
            }

        }
        else
        {
            wheelbackleft.brakeTorque = 0;
            wheelbackright.brakeTorque = 0;
        }

        speedvec = (transform.position - startingPosition) / Time.deltaTime;
        Speed = (int)(speedvec.magnitude) * 3.6; // 3.6 is the constant to convert a value from m/s to km/h, because i think that the speed wich is being calculated here is coming in m/s, if you want it in mph, you should use ~2,2374 instead of 3.6 (assuming that 1 mph = 1.609 kmh)

        startingPosition = transform.position;
        speedometer.text = Speed + "km/h";  // or mph
    }
}