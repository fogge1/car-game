using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CarMovement : MonoBehaviour
{
    public GameObject car;

    public float SteerForce, BreakForce, friction;
    public float motorForce = 5000f;

    public WheelCollider wheelfrontleft, wheelfrontrightSphere, wheelbackleft, wheelbackright;
    public Transform frontLeftT, frontRightT;
    public Transform rearLeftT, rearRightT;
    public float maxSteerAngle = 30f;
    

    [SerializeField] TextMeshProUGUI speedometer;
    private double Speed;
    private Vector3 startingPosition, speedvec;

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    private void Start()
    {
        startingPosition = transform.position;

    }

    void FixedUpdate()
    {
        Steer();
        UpdateWheelPoses();
        Accelerate();
        GetSpeed();
    }

    void GetSpeed()
    {
        speedvec = (transform.position - startingPosition) / Time.deltaTime;
        Speed = (float)(speedvec.magnitude) * 3.6; // 3.6 is the constant to convert a value from m/s to km/h, because i think that the speed wich is being calculated here is coming in m/s, if you want it in mph, you should use ~2,2374 instead of 3.6 (assuming that 1 mph = 1.609 kmh)
        startingPosition = transform.position;
        speedometer.text = Math.Round(Speed, 0) + "km/h";  // or mph
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * Input.GetAxis("Horizontal"); ;
        wheelfrontleft.steerAngle = m_steeringAngle;
        wheelfrontrightSphere.steerAngle = m_steeringAngle;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelfrontleft, frontLeftT);
        UpdateWheelPose(wheelfrontrightSphere, frontRightT);
        UpdateWheelPose(wheelbackleft, rearLeftT);
        UpdateWheelPose(wheelbackright, rearRightT);
    }

    private void Accelerate()
    {

        float v = Input.GetAxis("Vertical") * 5000f;

        wheelbackleft.motorTorque = v;
        wheelbackright.motorTorque = v;

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
    }

}