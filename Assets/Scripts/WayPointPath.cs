using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WayPointPath : MonoBehaviour
{    
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] private int currentWayPointIndex =0;
    [SerializeField] private GameObject PlatformTarget;
    [SerializeField] private float speed =1f;
    [SerializeField] private float DistanceBetween =.1f;
    // Start is called before the first frame update

    private LineRenderer lineRenderer;

    public int Length
    {
        get
        {
            return transform.childCount;
        }
    }

    void Start()
    {
        Vector3[] waypoints=new Vector3[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i).position;
        }
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
        
        PlatformTarget.transform.position =Vector3.MoveTowards(PlatformTarget.transform.position,wayPoints[currentWayPointIndex].transform.position,speed*Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 last = transform.GetChild(0).position;
        for (int i = 1; i < transform.childCount; i++)
        {
            Vector3 next = transform.GetChild(i).position;
            Gizmos.DrawLine(last, next);
            last = next;
        } 
    }
}

