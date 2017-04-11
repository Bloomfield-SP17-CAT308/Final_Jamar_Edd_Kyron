using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour 
{
    public void toTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void toGame()
    {
        SceneManager.LoadScene(1);
    }

    public void toHelp()
    {
        SceneManager.LoadScene(2);
    }

}
