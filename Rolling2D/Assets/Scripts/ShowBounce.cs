using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBounce : MonoBehaviour 
{

   
    private Animator anim;
    private Rigidbody2D rb;



    public AudioClip bounce;
    private AudioSource auSo;

    [SerializeField]
    private  bool canJump, downATK;
    public float jumpPower;
    public Collider2D coll;
    public PhysicsMaterial2D phys;
   
    [SerializeField]




    void Start () 
    {
       
        auSo = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
      
        rb = GetComponent<Rigidbody2D>();
       
        canJump = true;
        coll = GetComponent<Collider2D>();
        downATK = false;
      
    }

    void Update()
    {

    

        // print((int)travelDis + "/ 500" +  "" + (int)travelDis% 500);
       
    


        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            Jump();


  
        if (Input.GetKeyDown(KeyCode.Space) && !canJump && !downATK)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, -800));
            coll.sharedMaterial = phys;
            downATK = true;
        }


        if (downATK)
            anim.SetBool("Forcing", true);
        else
            anim.SetBool("Forcing", false);
    }

    

    void FixedUpdate () 
    {

       // if(alive)
       //     Roll(1);

        if (rb.IsTouchingLayers(1<<8))
            canJump = true;
        else
            canJump = false;

        if (Input.GetKeyDown(KeyCode.Q))
            coll.sharedMaterial = null;

  
    }



    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpPower));
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (downATK)
        if (other.gameObject.CompareTag("Platform") || (other.gameObject.CompareTag("Enemy") ))
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                auSo.clip = bounce;
                auSo.Play();
            }
            downATK = false;
            coll.sharedMaterial = null;
        }


    }
       

}
