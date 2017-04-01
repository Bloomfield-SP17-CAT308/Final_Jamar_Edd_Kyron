using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    

    public Transform playerPos;


	void Start () 
    {
        
	}
	
	
	void Update () 
    {
        transform.position = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
	}
}
