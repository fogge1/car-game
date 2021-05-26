using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CarMovement : MonoBehaviour
{
    public GameObject car;

    public float SteerForce, BreakForce, friction;
    private float motorForce = 5000f;

    public WheelCollider wheelfrontleft, wheelfrontright, wheelbackleft, wheelbackright;
    public Transform frontLeftT, frontRightT;
    public Transform rearLeftT, rearRightT;
    public float maxSteerAngle = 30f;
    

    [SerializeField] TextMeshProUGUI speedometer;
    private double Speed;
    private Vector3 lastPosition, speedvec;

    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    private void Start()
    {   
        // Get starting position to 
        lastPosition = transform.position; 
    }

    void FixedUpdate()
    {
        steerCar();
        updateWheelPoses();
        drive();
        getSpeed();
    }

    void getSpeed()
    {
        speedvec = (transform.position - lastPosition) / Time.deltaTime; // Define variable for how many position changes since last frame
        Speed = (float)(speedvec.magnitude) * 3.6; 
        lastPosition = transform.position;
        speedometer.text = Math.Round(Speed, 0) + "km/h";
    }

    // Update the wheel mesh position to the wheelcollider position
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void steerCar()
    {
        steeringAngle = maxSteerAngle * Input.GetAxis("Horizontal"); ;
        wheelfrontleft.steerAngle = steeringAngle;
        wheelfrontright.steerAngle = steeringAngle;
    }

    private void updateWheelPoses()
    {
        UpdateWheelPose(wheelfrontleft, frontLeftT);
        UpdateWheelPose(wheelfrontright, frontRightT);
        UpdateWheelPose(wheelbackleft, rearLeftT);
        UpdateWheelPose(wheelbackright, rearRightT);
    }

    private void drive()
    {

        float v = Input.GetAxis("Vertical") * motorForce;

        // set the torque of the rear wheels to the variable V defined earlier (makes the car move forward)
        wheelbackleft.motorTorque = v;
        wheelbackright.motorTorque = v;

        // brakes te car
        if (Input.GetKey(KeyCode.Space))
        {
            wheelbackleft.brakeTorque = BreakForce;
            wheelbackright.brakeTorque = BreakForce;
        }
        // When space is released set brakeTorque to 0 to make the car stop braking
        if (Input.GetKeyUp(KeyCode.Space))
        {
            wheelbackleft.brakeTorque = 0;
            wheelbackright.brakeTorque = 0;
        }
        // If the "driving buttons" isn't getting input slow down the car
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
        // If the "driving buttons" gets input don't brake
        else
        {
            wheelbackleft.brakeTorque = 0;
            wheelbackright.brakeTorque = 0;
        }
    }

}