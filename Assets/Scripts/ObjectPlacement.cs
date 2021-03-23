using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pose = RosMessageTypes.Geometry.Pose;
using RosMessageTypes.RoboticsDemo;
public class ObjectPlacement : MonoBehaviour
{

    public GameObject prefab;
    // float posx;
    // float posy;
    // float posz;
    float depth = 1f;
    float width = 1f;
    float height = 1f;
    float mass;
    float alfa = 0f;


    private Rigidbody cub;

    private Rigidbody cyli;
    public Transform FPSframe;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;
    private int nextCubeNumber=0;
    private int nextCylNumber=0;
    private int nextRedNumber=0;
    bool isGrounded;
    void Start()
    {

        ROSConnection.instance.Subscribe<ObjectPosSize>("Object_pos", Obj_callback);
    }

    void Obj_callback(ObjectPosSize data)
    {
        
        //to be continued
        //Need object size too!
        depth = data.depth;
        width = data.width;
        height = data.height;
        mass = data.mass;


    }

    // Update is called once per frame
    void Update()
    {
        // Press to create cube
        bool cu = Input.GetKeyDown(KeyCode.C);
        bool cy = Input.GetKeyDown(KeyCode.Y);
        bool red = Input.GetKeyDown(KeyCode.R);
        // Press to create
        if (cu == true)
        {
            alfa = FPSframe.transform.eulerAngles[1];
            print("alfa:"+alfa);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
            FPSframe.transform.position[1], 
            FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth));
            cube.transform.rotation = FPSframe.transform.rotation;
            cube.transform.localScale = new Vector3(width, height, 1);
            cube.name = "Cube"+nextCubeNumber;
            nextCubeNumber++;
            cube.AddComponent<Rigidbody>();
            cub = cube.GetComponent<Rigidbody>();
            cub.mass = mass;
            cube.AddComponent<OdometryPub2>();
        }

        // Press to create
        if (cy == true)
        {
            alfa = FPSframe.transform.eulerAngles[1];
            print("alfa:"+alfa);
            GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cyl.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
            FPSframe.transform.position[1], 
            FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth));
            cyl.transform.rotation = FPSframe.transform.rotation;
            cyl.transform.localScale = new Vector3(width, height, width);
            cyl.name = "Cyl"+nextCylNumber;
            nextCylNumber++;
            cyl.AddComponent<Rigidbody>();
            cyli = cyl.GetComponent<Rigidbody>();
            cyli.mass = mass;
            cyl.AddComponent<OdometryPub2>();

        } 
        // Press to create
        if (red == true)
        {
            alfa = FPSframe.transform.eulerAngles[1];
            print("alfa:"+alfa);
            // GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            // cyl.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
            // FPSframe.transform.position[1], 
            // FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth));
            // // cube.transform.rotation = 
            // cyl.transform.localScale = new Vector3(width, height, width);
            Instantiate(prefab,new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
            FPSframe.transform.position[1], 
            FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth)),
            // Quaternion.identity
            FPSframe.transform.rotation);
            prefab.name = "RedCube"+nextRedNumber;
            nextRedNumber++;
        } 

    }
}

