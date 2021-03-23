using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{

    public void GetInput()
    {
        m_HorizontalInput = Input.GetAxis("Horizontal"); // Gets axis from Unity's defaults
        m_VerticalInput = Input.GetAxis("Vertical");


    }

    private void Steer()
    {
        m_streeringAngle = maxSteeringAngle * m_HorizontalInput;
        rightWheelW.steerAngle = m_streeringAngle;
        leftWheelW.steerAngle = m_streeringAngle;


    }

    private void Accelerate()
    {
        leftWheelW.motorTorque = motorForce * m_VerticalInput;
        rightWheelW.motorTorque = motorForce * m_VerticalInput;
    }

    private void UpdateWheelPoses() 
    {
        UpdateWheelPose(rightWheelW,rightWheelT);
        UpdateWheelPose(leftWheelW,leftWheelT);
        // UpdateWheelPose(rearPassengerW,rearPassengerT);
        // UpdateWheelPose(rearDriverW,rearDriverT);
        
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        // Initialization
        Vector3 _pos = _transform.position;
        Quaternion _rot = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _rot);
        _transform.position = _pos;
        _transform.rotation = _rot;
        

    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }



    private float m_HorizontalInput;
    private float m_VerticalInput;
    private float m_streeringAngle;

    public WheelCollider leftWheelW;
    public WheelCollider rightWheelW;
    // public WheelCollider rearDriverW;
    // public WheelCollider rearPassengerW;

    public Transform leftWheelT;
    public Transform rightWheelT;
    // public Transform rearDriverT;
    // public Transform rearPassengerT;

    public float maxSteeringAngle=30;
    public float motorForce=50;
    
}
