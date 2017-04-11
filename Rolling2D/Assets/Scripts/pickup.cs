using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!(other.GetComponent<Roller>().lives >= 3))
                other.GetComponent<Roller>().lives += 1;
            Destroy(gameObject);
        }
    }
	
}
