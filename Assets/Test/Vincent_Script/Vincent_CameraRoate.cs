using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vincent_CameraRoate : MonoBehaviour
{   

    [SerializeField] private float SmoothFactor =0.5f;
    [SerializeField] private Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField]private float turnSpeed = 5.0f;
    public bool RoateAroundPlayer =true;
    [SerializeField] private bool LookAtPlayer =false;

    
    [SerializeField] private float CamerasmoothSpeed =0.125f;
    [SerializeField] Vector3 CameraSet;

    void Start()
    {
        offset = transform.position -target.transform.position;
    }


    void LateUpdate()
    {   
        Zoom();
        
        if(RoateAroundPlayer && Input.GetMouseButton(0))
        {   
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed,Vector3.up);
            Quaternion Yaw = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed,Vector3.right);
            offset =camTurnAngle * offset;
            offset =Yaw *offset;
        }
        Vector3 newPos = target.transform.position + offset;

        // Vector3 desiredPosition =target.position + CameraSet;
        // Vector3 SmoothPosition =Vector3.Lerp(transform.position,desiredPosition,CamerasmoothSpeed);
        transform.position = Vector3.Slerp(transform.position,newPos,SmoothFactor);

        if(LookAtPlayer|| RoateAroundPlayer){
            transform.LookAt(target.transform);
        }

        if(Input.GetMouseButtonUp(0)){
            Vector3 desiredPosition =target.position + CameraSet;
            Vector3 SmoothPosition =Vector3.Lerp(transform.position,desiredPosition,CamerasmoothSpeed);
            transform.position =SmoothPosition;
        }
        
    }

    void Zoom(){
        if(Input.GetAxis("Mouse ScrollWheel")>0){
            GetComponent<Camera> ().fieldOfView--;
        }

        if(Input.GetAxis("Mouse ScrollWheel")<0){
            GetComponent<Camera> ().fieldOfView++;
        }
    }

}
