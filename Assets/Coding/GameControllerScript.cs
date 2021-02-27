using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public GameObject roundedCircle, clickCircle;
    public Animator animator;
    public Text levelText,needleLeftText;
    public int howManyNeedle;
    bool goNewLevel = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Kayit", int.Parse(SceneManager.GetActiveScene().name));
        //roundedCircle = GameObject.FindGameObjectWithTag("RoundedCircleTag");        
        levelText.text = SceneManager.GetActiveScene().name;
        needleLeftText.text = howManyNeedle + "";
    }

    public void GameOver()
    {
        StartCoroutine(CallGameOver());
    }

    IEnumerator CallGameOver()
    {
        roundedCircle.GetComponent<SpinningCode>().enabled = false;
        clickCircle.GetComponent<ThrowingCircleScript>().enabled = false;
        animator.SetTrigger("GameOverTrigger");
        goNewLevel = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowHowManyLeft()
    {
        howManyNeedle--;
        needleLeftText.text = howManyNeedle + "";
        if(howManyNeedle==0)
        {
            StartCoroutine(newLevel());
        }
    }

    IEnumerator newLevel()
    {
        roundedCircle.GetComponent<SpinningCode>().enabled = false;
        clickCircle.GetComponent<ThrowingCircleScript>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        if (goNewLevel)
        {
            animator.SetTrigger("NewLevelTrigger");
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
    }
}
