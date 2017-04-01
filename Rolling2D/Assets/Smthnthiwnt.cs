using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smthnthiwnt : MonoBehaviour 
{

    public GameObject post;
	void Start () 
    {
        for(int i = 0; i < 40; i++)
        {
            Instantiate(post, new Vector3(post.transform.position.x + 10 * i, post.transform.position.y, post.transform.position.z), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

}
