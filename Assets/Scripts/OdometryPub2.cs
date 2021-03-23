using RosMessageTypes.RoboticsDemo;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// Not working for now
/// </summary>
public class OdometryPub2 : MonoBehaviour
{
    ROSConnection ros;
    private string topicName="odom_2";
    // The GameObject 
    // public Rigidbody rb;
    GameObject _gameObject;
    // Publish the target's position and rotation every N seconds
    Transform _transform;
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;
    private Vector3 orientation;
    void Start()
    {
        _transform = transform;
   //or if you want it to be the root transform...
        // _transform = transform.root;
      
      
        _gameObject = _transform.gameObject;
        // start the ROS connection
        ros = ROSConnection.instance;

    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            // Initialization
            Odometry2 targetOdom = new Odometry2(
                _gameObject.name,
                _transform.transform.position.z, 
                -_transform.transform.position.x,
                _transform.transform.position.y,
                _transform.transform.eulerAngles.z,
                _transform.transform.eulerAngles.x,
                _transform.transform.eulerAngles.y,

                // target.transform.rotation.x,
                // target.transform.rotation.y,
                // target.transform.rotation.z,
                // target.transform.rotation.w,
                // Mathf.Abs(rb.velocity[2]*Mathf.Cos((Mathf.PI / 180)*target.transform.eulerAngles.y)) + Mathf.Abs(rb.velocity[0]*Mathf.Sin((Mathf.PI / 180)*target.transform.eulerAngles.y)),
                // rb.velocity[0],
                // rb.velocity[1],
                // rb.angularVelocity[2],
                // rb.angularVelocity[0],
                // rb.angularVelocity[1]
                0,
                0,
                0,
                0,
                0,
                0
                
            ) ;
            // PosRot targetOdom = new PosRot(0,0,0,0,0,0,0);
            // target.GetWorldPose(out _pos, out _rot);
            // Finally send the message to server_endpoint.py running in ROS
            ros.Send(topicName, targetOdom);

            timeElapsed = 0;
        }
    }
}
