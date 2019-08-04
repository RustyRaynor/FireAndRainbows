using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject explosion;
    Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Vector3 position = collision.gameObject.transform.position;
            Instantiate(explosion, position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
}
