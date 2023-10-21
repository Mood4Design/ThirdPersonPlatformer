using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vincent_WayPointPath : MonoBehaviour
{   
    [SerializeField] GameObject[] wayPoints;

    [SerializeField] private int currentWayPointIndex =0;

    [SerializeField] private float speed =1f;

    [SerializeField] private float DistanceBetween =.1f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        transform.position =Vector3.MoveTowards(transform.position,wayPoints[currentWayPointIndex].transform.position,speed*Time.deltaTime);
    }
}
