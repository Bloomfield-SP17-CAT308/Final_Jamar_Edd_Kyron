using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThing : MonoBehaviour 
{
    public bool kicker;
    private Rigidbody2D rb;
    private bool canJump;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    void Update()
    {
        if (rb.IsTouchingLayers(1 << 8))
            canJump = true;
        else
            canJump = false;
        if (gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.None)
            StartCoroutine(expire());
    }

    IEnumerator expire()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.None )
        {
            
            if (!kicker && canJump)
            {
                anim.SetBool("RollerNear", true);
                rb.AddForce(new Vector2(0, 500));

            }

            if (kicker)
                anim.SetTrigger("RollerNear");
        }


        if (!kicker && other.CompareTag("Platform"))
            anim.SetBool("RollerNear", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pothole"))
            transform.position -= new Vector3(-1, 0, 0);
    }

}
