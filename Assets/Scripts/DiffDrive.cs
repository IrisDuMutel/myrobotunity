using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffDrive : MonoBehaviour
{

    public void GetInput()
    {
        m_HorizontalInput = Input.GetAxis("Horizontal"); // Gets axis from Unity's defaults
        m_VerticalInput = Input.GetAxis("Vertical"); // Both values ar in the range -1...1


    }



    private void Accelerate()
    {
        leftWheelW.motorTorque = motorForce * m_VerticalInput - maxSteeringAngle*m_HorizontalInput;
        rightWheelW.motorTorque = motorForce * m_VerticalInput + maxSteeringAngle*m_HorizontalInput;
        // Debug.Log(leftWheelW.rpm);
    }

    private void UpdateWheelPoses() 
    {
        UpdateWheelPose(rightWheelW,rightWheelT);
        UpdateWheelPose(leftWheelW,leftWheelT);

        
    }

    private void OnGUI()
    {
      print("The variable is :"+leftWheelW.rpm);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        // Initialization
        Vector3 _pos = _transform.position;
        Quaternion _rot = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _rot);
        _transform.position = _pos;
        // _transform.rotation = _rot; // this line makes the rotation of the mesh return to 0 and move with the collider
        

    }

    private void FixedUpdate()
    {
        GetInput();
        Accelerate();
        UpdateWheelPoses();
    }



    private float m_HorizontalInput;
    private float m_VerticalInput;
    private float m_streeringAngle;

    public WheelCollider leftWheelW;
    public WheelCollider rightWheelW;


    public Transform leftWheelT;
    public Transform rightWheelT;

    public float maxSteeringAngle=10;
    public float motorForce=10;
    
}

