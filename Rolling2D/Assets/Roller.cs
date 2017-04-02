using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour 
{

    [SerializeField]
    private float speed;
    private float maxSpeed = 20;
    private Rigidbody2D rb;


    [SerializeField]
    private  bool canJump, downATK;
    public float jumpPower;
    public Collider2D coll;
    public PhysicsMaterial2D phys;
    public Material Green, Red;

	
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
        canJump = true;
        coll = GetComponent<Collider2D>();
        downATK = false;
	}
	
	
	void Update () 
    {
        
        Roll(1);
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            Jump();
        
        if (downATK)
            GetComponent<MeshRenderer>().material.color = Red.color;
        else
            GetComponent<MeshRenderer>().material.color = Green.color;
         

        if (Input.GetKeyDown(KeyCode.Space) && !canJump && !downATK)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, -700));
            coll.sharedMaterial = phys;
            downATK = true;
        }




        if (Input.GetKeyDown(KeyCode.Q))
            coll.sharedMaterial = null;

        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);


        if (rb.IsTouchingLayers(1<<8))
            canJump = true;
        else
            canJump = false;


	}

    void Roll(float magnitude)
    {
        rb.AddForce(new Vector3(magnitude*speed, 0));
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpPower));

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (downATK)
        if (other.gameObject.CompareTag("Platform") || (other.gameObject.CompareTag("Enemy") && other.gameObject.layer == 8))
        {
            print("what");
            downATK = false;
            coll.sharedMaterial = null;
        }
            
            
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(downATK)
        if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        if (!downATK)
        if (other.gameObject.CompareTag("Enemy"))
            rb.AddForce(new Vector2(-200, 0));
    }


}
