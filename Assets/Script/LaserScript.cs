using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject explosion;
    

    Rigidbody2D rb2d;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Debug.Log("Move");
        transform.position += Vector3.right * speed;
        BoundaryCheck();
    }
    void BoundaryCheck()
    {
        if (transform.position.x >= 11)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.Find("GameManager").GetComponent<ScoreCounter>().enemyScore += 50;
            Vector3 position = collision.gameObject.transform.position;
            Instantiate(explosion, position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}