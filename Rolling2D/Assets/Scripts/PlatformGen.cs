using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour {

    public GameObject street;
    public GameObject enemy;
    public Transform genPoint;

    private float platformWidth;


	void Start () 
    {
        platformWidth = street.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.x < genPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            Instantiate(street, transform.position, transform.rotation);

            int i = Random.Range(2, 7);
            if (i < 4)
            Instantiate(enemy, new Vector3(transform.position.x + 5, enemy.transform.position.y, enemy.transform.position.z), Quaternion.identity);

        }
	}
}
