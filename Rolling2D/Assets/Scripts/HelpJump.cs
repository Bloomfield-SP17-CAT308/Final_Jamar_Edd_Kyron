using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpJump : MonoBehaviour 
{

	

    private Rigidbody2D rb;
   
    private  bool canJump, downATK;
    public Collider2D coll;
    public PhysicsMaterial2D phys;
    private float travelDis;
    private Animator anim;


    void Start () 
    {
       
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        coll = GetComponent<Collider2D>();
        downATK = false;


    }

    void Update()
    {

      


        if (downATK)
            anim.SetBool("Forcing", true);
        else
            anim.SetBool("Forcing", false);

    }

    void FixedUpdate () 
    {

      

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            Jump();
   
        if (Input.GetKeyDown(KeyCode.Space) && !canJump && !downATK)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, -800));
            coll.sharedMaterial = phys;
            downATK = true;
        }
            
        if (rb.IsTouchingLayers(1<<8))
            canJump = true;
        else
            canJump = false;


    }


    void Jump()
    {
        rb.AddForce(new Vector2(0, 400));

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (downATK)
        if (other.gameObject.CompareTag("Platform") || (other.gameObject.CompareTag("Enemy") ))
        {
            downATK = false;
            coll.sharedMaterial = null;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
    }
 

}
