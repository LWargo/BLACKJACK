using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class pig_script : MonoBehaviour
{
    public GameObject pid;

    public int stepCount;
    // Start is called before the first frame update
    void Start()
    {
       // walk();
        //InvokeRepeating("walk", .5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void walk(){
        Debug.Log("pid step");
        while(stepCount < 6){
            pid.transform.position = Vector3.right;
            stepCount++;
        }
        if(stepCount == 6){
            pid.transform.position = Vector3.left;
            stepCount--;
        }
        while(stepCount > 0){
            pid.transform.position = Vector3.left;
            stepCount--;
        }
        walk();
    }
}
