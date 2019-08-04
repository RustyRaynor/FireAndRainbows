using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Vector3 newPos = transform.position;
        newPos.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        transform.position = newPos;  
    }
}
