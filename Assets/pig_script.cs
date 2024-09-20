using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class pig_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("walk", .5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void walk(){
        if(transform.position.x < 6){
            transform.position = new Vector3(1,0,0);
        }
        if(transform.position.x == 6){
            transform.position = new Vector3(-1,0,0);
        }
    }
}
