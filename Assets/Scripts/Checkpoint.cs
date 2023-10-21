using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] private LogFile checkpointAnalytics;
    private Transform transform;
    public Transform Transform { get => transform; set => transform = value; }
    
    void OnTriggerEnter(Collider collider)
    {
        transform = gameObject.transform;
        Debug.Log("Checkpoint = " + gameObject.name);
        checkpointAnalytics.WriteLine(Time.time, transform.position, gameObject.name);   
    }
}
