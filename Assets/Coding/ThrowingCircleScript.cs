using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCircleScript : MonoBehaviour
{
    public GameObject needle;
    GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameControllerTag");
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            NeedleFirlat();

        }
    }
    void NeedleFirlat()
    {
        Instantiate(needle,transform.position,transform.rotation);
        gameController.GetComponent<GameControllerScript>().ShowHowManyLeft();

    }
}
