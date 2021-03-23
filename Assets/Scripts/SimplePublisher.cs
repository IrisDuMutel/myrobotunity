using RosMessageTypes.RoboticsDemo;
using UnityEngine;
using Random = UnityEngine.Random;
using target = RosMessageTypes.Geometry.Twist;

/// <summary>
/// 
/// </summary>
public class SimplePublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "simple_pub";
    private RosMessageTypes.Geometry.Vector3 aaa = new RosMessageTypes.Geometry.Vector3(1,0,0);

    // The GameObject 
    public GameObject cube;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

// RosMessageTypes.Geometry.Vector3 vec = new RosMessageTypes.Geometry.Vector3(1,1,1);
    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.instance;
        
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {   
            // cube.transform.rotation = Random.rotation;
            // RosMessageTypes.Std.UInt32 seq = new RosMessageTypes.Std.UInt32(flag);
            // flag++;
            // RosMessageTypes.Std.Time tiempo = new RosMessageTypes.Std.Time((uint)Time.time, (uint)Time.time);
            // string frame_id = "myrobot";
            // RosMessageTypes.Std.Header head = new RosMessageTypes.Std.Header(flag,tiempo,frame_id);
            
            target cubePos = new target(aaa,aaa
            );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Send(topicName, cubePos);

            timeElapsed = 0;
        }
    }
}

