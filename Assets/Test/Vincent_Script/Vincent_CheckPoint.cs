using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vincent_CheckPoint : MonoBehaviour
{   
    private Transform transform;
    public Transform Transform { get => transform; set => transform = value; }
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoint;

    //CheckPoint Pos
    [SerializeField] Vector3 vectorPoint;
    
    // Player dies in certain distance when falling off the platform
    [SerializeField] float deadDist;
    // Update is called once per frame

    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
      // Respawn player after falling off the platform in certain distance 
      if(player.transform.position.y <-deadDist)
      {
          SetRespawn();
      }
      
    }

    private void OnTriggerEnter(Collider other)
    {   
      //Get Data
      if(other.tag =="Playre"){
        transform = player.transform;
        Debug.Log("name = " + other.name);

      }
      vectorPoint =player.transform.position;
    
    }


    //Player back to checkPoint
    public void SetRespawn()
    {
        player.transform.position =vectorPoint;
    }
}
