using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArm : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform arm_base;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        arm_base.Rotate(0, 1, 0);
    }
}
