using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRoll : MonoBehaviour {

    private Rigidbody2D rb;
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        rb.AddForce(new Vector3(6, 0));

        if (rb.velocity.x > 20)
            rb.velocity = new Vector2(0, 0);
	}
}
