using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Move");
        rb2d.AddForce(transform.right * force);
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
