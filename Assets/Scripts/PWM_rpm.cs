using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PWM = RosMessageTypes.RoboticsDemo.PWM;


public class PWM_rpm : MonoBehaviour
{
    // private float m_HorizontalInput;
    // private float m_VerticalInput;
    private float PWM_leftWheel;
    private float PWM_rightWheel;
    private float rpm_model_left;
    private float rpm_model_right;
    private float tolerance;
    
    public float K_p;


    public WheelCollider leftWheelW;
    public WheelCollider rightWheelW;


    public Transform leftWheelT;
    public Transform rightWheelT;



    void Start()
    {
        ROSConnection.instance.Subscribe<PWM>("pwm_cmd", PWM_callback);
    }

    void PWM_callback(PWM data)
    {
        PWM_leftWheel = data.pwm_left;        
        PWM_rightWheel = data.pwm_right;
    }

    void PWM_2_rpm()
    {
        // Introduce the real model when available
        rpm_model_left = PWM_leftWheel;
        rpm_model_right = PWM_rightWheel;
    }

    // public void GetInput()
    // {
    //     m_HorizontalInput = Input.GetAxis("Horizontal"); // Gets axis from Unity's defaults
    //     m_VerticalInput = Input.GetAxis("Vertical"); // Both values ar in the range -1...1


    // }



    private void Accelerate()
    {
        leftWheelW.motorTorque = 5;
        rightWheelW.motorTorque = 5;
        
        if(Math.Abs(leftWheelW.rpm - rpm_model_left)>=tolerance){
            leftWheelW.motorTorque = K_p*(-leftWheelW.rpm + rpm_model_left);

        }
        if(Math.Abs(rightWheelW.rpm - rpm_model_right)>=tolerance){
            rightWheelW.motorTorque = K_p*(-rightWheelW.rpm + rpm_model_right); 

        }

         
        // Debug.Log(leftWheelW.rpm);
    }

    private void UpdateWheelPoses() 
    {
        UpdateWheelPose(rightWheelW,rightWheelT);
        UpdateWheelPose(leftWheelW,leftWheelT);
    }

    private void OnGUI()
    {
      print("Real rpm :"+leftWheelW.rpm);
      print("Desired rpm :"+rpm_model_left);
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
        // GetInput();
        PWM_2_rpm();
        Accelerate();
        UpdateWheelPoses();
    }



    
}
