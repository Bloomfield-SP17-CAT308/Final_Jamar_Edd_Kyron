using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthShow : MonoBehaviour 
{

    public GameObject p;
    private Roller player;
    private GameObject[] healths;
	void Start () 
    {
        player = p.GetComponent<Roller>();
        healths = GameObject.FindGameObjectsWithTag("Life");
	}
	
	
	void Update () 
    {
        checkHealth(player.lives);
	}

    void checkHealth(int lives)
    {
        int countLives = 0;
        int difference = 0;

        for (int i = 0; i < healths.Length; i++)
            if (healths[i].activeSelf)
                countLives++;

        if (countLives < lives)
            for (int i = 0; i < healths.Length; i++)
                if (difference == lives - countLives)
                    break;
                else if (healths[i].activeSelf == false)
                {
                    healths[i].SetActive(true);
                    difference++;
                }

        if (countLives > lives)
            for (int i = 0; i < healths.Length; i++)
                if (difference == countLives - lives)
                    break;
                else if (healths[i].activeSelf)
                {
                    healths[i].SetActive(false);
                    difference++;
                }
    }
   
}
