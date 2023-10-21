using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
public class Vincent_Laser2 : MonoBehaviour
{   
    private LineRenderer lr;
    private float LengthOfLine =1000;
    // Start is called before the first frame update
    void Start()
    {
        lr =GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit ;
        if(Physics.Raycast(transform.position,transform.forward,out hit)){
            if(hit.collider)
            {
                lr.SetPosition(1,new Vector3(0,0,hit.distance));
            }
        }else{
            lr.SetPosition(1,new Vector3(0,0,LengthOfLine));
        }
    }
}
