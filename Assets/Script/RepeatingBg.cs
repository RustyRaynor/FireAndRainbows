using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBg : MonoBehaviour
{
    float horizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        horizontalLength = GetComponent<SpriteRenderer>().bounds.size.x;   
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -horizontalLength)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector3 offset = new Vector3(horizontalLength * 2f, 0, 0);
        transform.position = transform.position + offset;
    }
}
