using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float destroyOffset;
    Rigidbody2D rigidbody;
    Vector2 value;
    float limitWorldX;

    void Start()
    {
        limitWorldX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        value = -Vector2.right * GameManager.scrollAmount * speed;
        rigidbody.velocity = value;
        if(transform.position.x + destroyOffset < -limitWorldX)Destroy(gameObject);
    }
}
