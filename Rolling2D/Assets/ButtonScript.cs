using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour 
{
    private AudioSource audiO;
    public AudioClip bounceSound;
     
    void Awake()
    {
       
        gameObject.AddComponent<AudioSource>();
        audiO = GetComponent<AudioSource>();
        audiO.playOnAwake = false;
    }
    void Start()
    {
        audiO.clip = bounceSound;
    }

    public void toTitle()
    {
        audiO.Play();
        StartCoroutine(WaitForAudio(0));
          
    }

    public void toGame()
    {
        audiO.Play();
        StartCoroutine(WaitForAudio(1));
          
    }

    public void toHelp()
    {
        audiO.Play();
        StartCoroutine(WaitForAudio(2));
           
    }

    IEnumerator WaitForAudio(int buildIndex)
    {
        yield return new WaitUntil(()=> audiO.isPlaying == false);
        SceneManager.LoadScene(buildIndex);

    }
}
