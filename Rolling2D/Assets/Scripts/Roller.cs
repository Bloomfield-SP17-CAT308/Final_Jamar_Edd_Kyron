using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roller : MonoBehaviour 
{

    [SerializeField]
    private float speed;
    private float maxSpeed;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 origPos;
    private bool alive;


    public AudioClip hit, hurt, bounce;
    private AudioSource auSo;

    [SerializeField]
    private  bool canJump, downATK;
    public float jumpPower;
    public Collider2D coll;
    public PhysicsMaterial2D phys;
    public Text distance;
    [SerializeField]
    public int lives;
    public GameObject[] lifes;
    private float travelDis;
    public GameObject playAgain;
   
	
	void Start () 
    {
        playAgain.SetActive(false);
        auSo = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        maxSpeed = 9;
        travelDis = 0;
        alive = true;
        lifes = GameObject.FindGameObjectsWithTag("Life");
        lives = lifes.Length;
        origPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
        canJump = true;
        coll = GetComponent<Collider2D>();
        downATK = false;


	}
	
    void Update()
    {
        
        travelDis = transform.position.x - origPos.x;
        if(alive)
            distance.text = (int)(travelDis) + "";
        else
            StartCoroutine(GameOver());


        if (downATK)
            anim.SetBool("Forcing", true);
        else
            anim.SetBool("Forcing", false);
        
        if ((int)travelDis == 300)
        {
            maxSpeed++;
            print("speed up!");
        }
        else if ((int)travelDis == 500)
        {
            maxSpeed++;
            print("speed up!"); 
        }
        else if ((int)travelDis == 1000)
        {
            maxSpeed += 2;
            print("ped");
        }
        else if (((int)travelDis) % 500 == 0)
            maxSpeed += 3;

    }

	void FixedUpdate () 
    {

        if(alive)
            Roll(1);

        if(alive)
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            Jump();
        if(alive)
        if (Input.GetKeyDown(KeyCode.Space) && !canJump && !downATK)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, -800));
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (downATK)
        if (other.gameObject.CompareTag("Enemy"))
        {
            auSo.clip = hit;
            auSo.Play();
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        if (!downATK)
        if (other.gameObject.CompareTag("Enemy") && other.gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.FreezeRotation)
        {
            auSo.clip = hurt;
            auSo.Play();
            if (lives == 0)
                alive = false;
            rb.AddForce(new Vector2(-800, 0));
            if (alive)
                lives--;
        }


        if (other.gameObject.CompareTag("Pothole"))
        {
            auSo.clip = hurt;
            auSo.Play();
            if (lives == 0)
                alive = false;
            
            if (alive)
                lives--;
            
        }
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        distance.text = "Game Over";
        playAgain.SetActive(true);
    }


}
