using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour 
{

    public GameObject destroyPoint;
	void Start () 
    {
        destroyPoint = GameObject.FindGameObjectWithTag("Destroy");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.x < destroyPoint.transform.position.x)
            Destroy(gameObject);
		
	}
}
