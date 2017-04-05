using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSpawn : MonoBehaviour {

    public Transform respawnPoint;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            other.transform.position = new Vector3(respawnPoint.transform.position.x, other.transform.position.y, respawnPoint.transform.position.z);
    }
}
