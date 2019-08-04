using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailControl : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] float spacing, wind, windNoise, noiseStrength, noiseSpeed; 
  //  [SerializeField] TrailRenderer trailRenderer;

    void Start()
    {
        for (int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, (transform.position - Vector3.right * 10 * i) + Vector3.forward);
        }
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position + Vector3.forward);
        for (int i = 1; i < line.positionCount; i++)
        {
          Vector3 lastPos = line.GetPosition( i - 1);
          Vector3 dir = ((line.GetPosition(i) - lastPos) - Vector3.right * wind +  Vector3.up * Mathf.Sin(GameManager.scrollValue * noiseSpeed + (i * windNoise)) * noiseStrength).normalized;
          line.SetPosition(i, lastPos + dir * spacing);
        }
    }
}
