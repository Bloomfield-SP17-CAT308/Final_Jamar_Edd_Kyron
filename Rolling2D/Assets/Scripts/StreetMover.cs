using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMover : MonoBehaviour 
{
    private Rigidbody2D rb;
    private float speed = 5;
    private float maxSpeed = 20;
	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        rb.AddForce(new Vector3(speed, 0));

        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
		
	}
}
