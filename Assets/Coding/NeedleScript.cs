using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{
    Rigidbody2D physiscs;
    public float speed;
    bool moveControl = false;
    GameObject gameController;
    void Start()
    {
        physiscs = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameControllerTag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!moveControl)
        {
            physiscs.MovePosition(physiscs.position + Vector2.up * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "RotatingCircleTag")
        {
            transform.SetParent(col.transform);
            moveControl = true;
        }
        if(col.tag == "NeedleTag")
        {
            gameController.GetComponent<GameControllerScript>().GameOver();
        }
    }
}
