using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThing : MonoBehaviour 
{
    

    void Start()
    {

    }

    void Update()
    {
        if (gameObject.GetComponent<Rigidbody2D>().constraints == RigidbodyConstraints2D.None)
            StartCoroutine(expire());
    }

    IEnumerator expire()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
