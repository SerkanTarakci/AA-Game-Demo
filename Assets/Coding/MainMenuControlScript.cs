using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{
    public void Play()
    {
        if(PlayerPrefs.GetInt("Record")==0)
        {
            SceneManager.LoadScene("1");
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Record"));
        }
    }

    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

}
