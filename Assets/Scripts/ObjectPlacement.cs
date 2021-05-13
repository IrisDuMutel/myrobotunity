using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Pose = RosMessageTypes.Geometry.Pose;
using RosMessageTypes.RoboticsDemo;

public class ObjectPlacement : MonoBehaviour
{

    public GameObject prefab;
    uint num_boxes;
    float[] depth;
    float[] ymin_px;
    float[] xmin_px;
    float[] ymax_px;
    float[] xmax_px;
    float width_img;
    float height_img;
    string[] object_type;
    float mass = 1f;
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

        ROSConnection.instance.Subscribe<UnityScene>("unity_input", Obj_callback);
    }

    void Obj_callback(UnityScene data)
    {
        Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
        depth = data.depth;
        object_type = data.@object;
        
        // num_boxes = data.num_boxes;
        // width_img = data.width;
        // height_img = data.height;
        // ymin_px = data.ymin_px;
        // xmin_px = data.xmin_px;
        // ymax_px = data.ymax_px;
        // xmax_px = data.xmax_px;

    }

    // Update is called once per frame
    void Update()
    {
        foreach (String item in object_type)
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            if (item == "tv")
            {   
                var index = Array.FindIndex(object_type, row => row.Contains(item));
                float depth_bottle = depth[index];
               // Spawn bottle/cylinder 
                alfa = FPSframe.transform.eulerAngles[1];
                print("alfa:"+alfa);
                GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cyl.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth_bottle), 
                FPSframe.transform.position[1], 
                FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth_bottle));
                cyl.transform.rotation = FPSframe.transform.rotation;
                cyl.transform.localScale = new Vector3(0.2f, 0.5f, 0.2f);
                cyl.name = "Cyl"+nextCylNumber;
                nextCylNumber++;
                cyl.AddComponent<Rigidbody>();
                cyli = cyl.GetComponent<Rigidbody>();
                cyli.mass = mass;
                cyl.AddComponent<OdometryPub2>();
            }
        }
        // // Press to create cube
        // bool cu = Input.GetKeyDown(KeyCode.C);
        // bool cy = Input.GetKeyDown(KeyCode.Y);
        // bool red = Input.GetKeyDown(KeyCode.R);
        // // Press to create
        // if (cu == true)
        // {
        //     alfa = FPSframe.transform.eulerAngles[1];
        //     print("alfa:"+alfa);
        //     GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //     cube.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
        //     FPSframe.transform.position[1], 
        //     FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth));
        //     cube.transform.rotation = FPSframe.transform.rotation;
        //     cube.transform.localScale = new Vector3(width, height, 1);
        //     cube.name = "Cube"+nextCubeNumber;
        //     nextCubeNumber++;
        //     cube.AddComponent<Rigidbody>();
        //     cub = cube.GetComponent<Rigidbody>();
        //     cub.mass = mass;
        //     cube.AddComponent<OdometryPub2>();
        // }

        // // Press to create
        // if (cy == true)
        // {
        //     alfa = FPSframe.transform.eulerAngles[1];
        //     print("alfa:"+alfa);
        //     GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //     cyl.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
        //     FPSframe.transform.position[1], 
        //     FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth));
        //     cyl.transform.rotation = FPSframe.transform.rotation;
        //     cyl.transform.localScale = new Vector3(width, height, width);
        //     cyl.name = "Cyl"+nextCylNumber;
        //     nextCylNumber++;
        //     cyl.AddComponent<Rigidbody>();
        //     cyli = cyl.GetComponent<Rigidbody>();
        //     cyli.mass = mass;
        //     cyl.AddComponent<OdometryPub2>();

        // } 
        // // Press to create
        // if (red == true)
        // {
        //     alfa = FPSframe.transform.eulerAngles[1];
        //     print("alfa:"+alfa);
        //     // GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //     // cyl.transform.position = new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
        //     // FPSframe.transform.position[1], 
        //     // FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth));
        //     // // cube.transform.rotation = 
        //     // cyl.transform.localScale = new Vector3(width, height, width);
        //     Instantiate(prefab,new Vector3(FPSframe.transform.position[0]+Mathf.Sin(Mathf.PI/180*alfa)*(depth), 
        //     FPSframe.transform.position[1], 
        //     FPSframe.transform.position[2]+Mathf.Cos(Mathf.PI/180*alfa)*(depth)),
        //     // Quaternion.identity
        //     FPSframe.transform.rotation);
        //     prefab.name = "RedCube"+nextRedNumber;
        //     nextRedNumber++;
        // } 

    }
}

