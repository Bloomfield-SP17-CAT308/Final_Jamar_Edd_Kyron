using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour {

    public GameObject street1;
    public GameObject street2;
    public GameObject street3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject hole;
    public GameObject healths;
    public Transform genPoint;
    public GameObject checkP;

    public float distance;
    private Vector3 origPos;
    private GameObject enemy;
    private GameObject street;

    private float platformWidth;


	void Start () 
    {
        enemy = enemy1;
        street = street1;
        origPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        platformWidth = street.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        distance = transform.position.x - origPos.x;

        chooseEnemy();
        choosePlatform();

        if (transform.position.x < genPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            Instantiate(street, transform.position, transform.rotation);


            if (Random.Range(2, 7) < 4)
                Instantiate(enemy, new Vector3(transform.position.x + Random.Range(-7, 8), enemy.transform.position.y, enemy.transform.position.z), Quaternion.identity);

            if (Random.Range(1, 7) > 4)
                Instantiate(hole, new Vector3(transform.position.x + Random.Range(-6, 9), hole.transform.position.y, hole.transform.position.z), Quaternion.identity);

            if (Random.Range(0, 10) > 8)
                Instantiate(healths, new Vector3(transform.position.x, healths.transform.position.y, healths.transform.position.z), Quaternion.identity);

        }
	}

    void chooseEnemy()
    {
        if (Random.Range(0, 2) < 1)
            enemy = enemy1;
        else
            enemy = enemy2;
    }

    void choosePlatform()
    {
        int pick = Random.Range(0, 3);

        if (pick == 1)
            street = street1;
        if (pick == 2)
            street = street2;
        if (pick == 0)
            street = street3;
    }
}
