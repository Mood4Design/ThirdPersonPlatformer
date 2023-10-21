using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTeleport : MonoBehaviour
{
    private Transform transform;
    public Transform Transform { get => transform; set => transform = value; }
    [SerializeField] private LogFile teleporterAnalytics;
    [SerializeField] private bool inside;
    
    void Update(){
        if(inside ==true){
             if (Input.GetKeyDown("space")){
                Debug.Log("Hey");
                UIManager.Instance.LevelComplete();
             }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        inside = true;
        transform = gameObject.transform;
        Debug.Log("Teleporter");
        teleporterAnalytics.WriteLine(Time.time,transform.position, gameObject.name); 
    }

    void OnTriggerExit(Collider collider)
    {
        inside = false;
    }
}