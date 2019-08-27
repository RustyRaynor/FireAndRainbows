using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChange : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_Shift", 0);
    }

    public void Lava()
    {
        rend.material.SetFloat("_Shift", 2);
    }
    public void Mid()
    {
        rend.material.SetFloat("_Shift", 1);
    }
}
