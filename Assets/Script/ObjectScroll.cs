using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroll : MonoBehaviour
{
    [SerializeField] bool isEnemy;
    [SerializeField] float speed;
    Rigidbody2D rigidbody;
    Vector2 value;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        value = -Vector2.right * GameManager.scrollAmount * speed;
        rigidbody.velocity = value;
    }
}
