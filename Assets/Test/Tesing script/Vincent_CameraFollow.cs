
using UnityEngine;

public class Vincent_CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed =0.125f;
    [SerializeField] Vector3 CameraSet;
    
    


    //[SerializeField] private Camera cam;
    private Vector3 previousPosition;

    void Update(){
        Zoom();
    }

    void FixedUpdate ()
    {   
        //transform.LookAt(target);

        Vector3 desiredPosition =target.position + CameraSet;
        Vector3 SmoothPosition =Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position =SmoothPosition;

        
        
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
