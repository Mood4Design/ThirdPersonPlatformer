using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
public class Laser : MonoBehaviour
{   
    //ser laser color
    [SerializeField] private Color LaserColor;
    [SerializeField] private  PlayerCheckpoint Checkpoint;
    [SerializeField]private float LengthOfLine =200;
    private LineRenderer lineRenderer;
    void Start()
    {
        //Checkpoint = GetComponent<PlayerCheckpoint>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.SetColors(LaserColor,LaserColor);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit ;
        if(Physics.Raycast(transform.position,transform.forward,out hit)){
            if(hit.collider && hit.collider.tag != "Player")
            {
                lineRenderer.SetPosition(1,new Vector3(0,0,hit.distance));
            }
            //If Laser hits the Player, player will die and go back to checkpoint 
            if(hit.collider.tag == "Player")
            {   
                print("Hit : " +hit.collider.gameObject.name);
                //back to checkPoint
                StartCoroutine(LaserSetRespawn());     
            }
        }
        else
        {
            lineRenderer.SetPosition(1,new Vector3(0,0,LengthOfLine));
        }
    }
    private IEnumerator LaserSetRespawn()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            yield return wait;
            PointSetRespawn();
            yield break;
        }
    }
     void PointSetRespawn()
    {            
        Checkpoint.SetRespawn();
    }
}