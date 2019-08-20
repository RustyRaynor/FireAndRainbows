using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    GameManager manager;
    public GameObject managerObject;

    Rigidbody2D rb2d;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        manager = managerObject.GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.playerDead == false)
        {
            rb2d.velocity = new Vector2(manager.scrollSpeed * -speed, 0);
        }
        else
        {
            Debug.Log("This");
            rb2d.velocity = Vector2.zero;
        }
    }
}