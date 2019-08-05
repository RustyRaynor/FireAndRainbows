using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIUnit : MonoBehaviour
{
    [SerializeField] Transform[] segments;
    [SerializeField] float spaceX;
    [SerializeField] float spaceY;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] float ampX;
    [SerializeField] float ampY;
    [SerializeField] float vigor;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < segments.Length; i++){
            if(segments[i]){
                Vector2 shift = GetSpot(i);
                segments[i].position = new Vector3(transform.position.x + (spaceX * i) + shift.x , transform.position.y + (spaceY * i) + shift.y, segments[i].position.z);
            }
        }
    }

    Vector2 GetSpot(int count)
    {
        return new Vector2(Mathf.Sin(GameManager.scrollValue * vigor + (offsetX * count)) * ampX, Mathf.Sin(GameManager.scrollValue * vigor + (offsetY * count)) * ampY);
    }

}
