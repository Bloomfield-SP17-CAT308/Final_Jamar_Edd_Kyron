using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smthnthiwnt : MonoBehaviour 
{

    public GameObject post;
    public GameObject enemy;
	void Start () 
    {
        for(int i = 0; i < 40; i++)
        {
            Instantiate(post, new Vector3(post.transform.position.x + 10 * i, post.transform.position.y, post.transform.position.z), Quaternion.identity);
        }

        for (int i = 1; i < 10; i++)
            Instantiate(enemy, new Vector3(enemy.transform.position.x + 20 * i, enemy.transform.position.y, enemy.transform.position.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}

}
