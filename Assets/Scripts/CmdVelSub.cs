using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Twist = RosMessageTypes.Geometry.Twist;
public class CmdVelSub : MonoBehaviour
{
    private float m_HorizontalInput;
    private float m_VerticalInput;
    private float m_streeringAngle;
    private float cmdvel_left;
    private float cmdvel_right;
    public Rigidbody rb;
    public Transform _tr;
    public WheelCollider leftWheelW;
    public WheelCollider rightWheelW;
    public Transform leftWheelT;
    public Transform rightWheelT;
    private float vel_x;
    private float vel_y;
    private float vel_z;
    private float ang_x;
    private float ang_y;
    private float ang_z;
    public RFHandTransform RHtransformer;
    void Start()
    {

       ROSConnection.instance.Subscribe<Twist>("cmd_vel", Vel_callback);
    }

    void Vel_callback(Twist data)
    {
       vel_x = (float)data.linear.x;
       vel_y = (float)data.linear.y;
       vel_z = (float)data.linear.z;
       ang_x = (float)data.angular.x;
       ang_y = (float)data.angular.y;
       ang_z = (float)data.angular.z;

    }
    
    // void CmsVel_2_Wheels()
    // {
    //     // Introduce the real model when available
    //     // cmdvel_left = (float)vel_x/leftWheelW.radius* (float)3.5 + (float)ang_z*(float)1.95;
    //     // cmdvel_right = (float)vel_x/rightWheelW.radius* (float)3.5 - (float)ang_z*(float)1.95;
    // }

    // private void Accelerate()
    // {
        
    //     // // velocity comparison of the wheels in rad/sec
    //     // if(Math.Abs(leftWheelW.rpm*2*Math.PI/60 - cmdvel_left)>=tolerance){
    //     //     leftWheelW.motorTorque = K_p*(float)(Math.Round(-leftWheelW.rpm,2)*2*Math.PI/60+ cmdvel_left);

    //     // }
        
    //     // if(Math.Abs(rightWheelW.rpm*2*Math.PI/60 - cmdvel_right)>=tolerance){
    //     //     rightWheelW.motorTorque = K_p*(float)(Math.Round(-rightWheelW.rpm,2)*2*Math.PI/60 + cmdvel_right); 

    //     // }

         
    //     // Debug.Log(leftWheelW.rpm);
    // }

    private void UpdateWheelPoses() 
    {
        UpdateWheelPose(rightWheelW,rightWheelT);
        UpdateWheelPose(leftWheelW,leftWheelT);
    }

    // private void OnGUI()
    // {
    //   print("Real wheel rotation speed :"+leftWheelW.rpm*2*Math.PI/60);
    //   print("Desired rotation speed :"+cmdvel_left);
    // }

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
        RHtransformer.VelocityOnLeft(rb,_tr, vel_x, vel_y, ang_z);

        
        UpdateWheelPoses();
    }




}
