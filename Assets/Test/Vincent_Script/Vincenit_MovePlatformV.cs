using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vincenit_MovePlatformV : MonoBehaviour
{   
    [SerializeField] GameObject[] wayPoints;
    

    private int currentWayPointIndex =0;

    [SerializeField] private float speed =2f;

    private float DistanceBetween =.1f;
    private bool triggerCheck;
    // Start is called before the first frame update
    void Start()
    {
        triggerCheck =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,wayPoints[currentWayPointIndex].transform.position)<DistanceBetween)
        {
            currentWayPointIndex++;

            //return to first waypoint
            if(currentWayPointIndex>=wayPoints.Length){
                currentWayPointIndex =0;
            }
        }
        
        if(triggerCheck ==true){
            plateStartMoving();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerCheck =true;
    }

    
    void plateStartMoving(){
        transform.position =Vector3.MoveTowards(transform.position,wayPoints[currentWayPointIndex].transform.position,speed*Time.deltaTime);
    }

    
}
