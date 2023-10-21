using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraTracking : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetPosition = new Vector3(0,2,-5);
    [SerializeField] private Vector3 temp;
    [SerializeField] private float Modifier = 7f;
    [SerializeField] bool cameraStabilizer;
    public float mouseSensitivity = 10;
    public float dstFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2 (-40, 85);
    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    [SerializeField] private float yaw;
    [SerializeField] private float pitch;
    
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            return;
        }   
    }

    void LateUpdate()
    {
        if (!cameraStabilizer)
        {
            temp = target.position + target.TransformDirection(offsetPosition); 
            cameraStabilizer = true;
        }
        transform.position = Vector3.Lerp(transform.position,temp,Time.deltaTime * Modifier);
        //transform.LookAt(target);
        CamRotation();
        return;
    }

    void CamRotation()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity; 
        pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        transform.position = target.position - transform.forward * dstFromTarget; 
    }
}