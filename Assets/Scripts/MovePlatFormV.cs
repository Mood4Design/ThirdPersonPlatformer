using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatFormV : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    private int currentWayPointIndex =0;
    [SerializeField] private GameObject PlatformTarget;
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
        if(Vector3.Distance(PlatformTarget.transform.position,wayPoints[currentWayPointIndex].transform.position)<DistanceBetween)
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
    private void OnTriggerEnter (Collider Collider)
    {   
        if(Collider.gameObject.CompareTag("Player")){
            triggerCheck =true;
        }
        
    }
   
    void plateStartMoving(){
        PlatformTarget.transform.position =Vector3.MoveTowards(PlatformTarget.transform.position,wayPoints[currentWayPointIndex].transform.position,speed*Time.deltaTime);
    }
}

