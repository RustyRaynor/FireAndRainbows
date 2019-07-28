using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update
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
