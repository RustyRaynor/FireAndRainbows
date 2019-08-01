using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : MonoBehaviour
{
    protected bool active;
    protected int health;
    protected Rigidbody2D rigidbody;
    public float ctrlValue, shiftValue;

    void Start()
    {
        health = 100;
        active = true;
        rigidbody = GetComponent<Rigidbody2D>();
        SubStart();
    }

    void Update()
    {
        if(health > 0)Action();
        else if(active) Death();
    }

    public abstract void SubStart();
    public abstract void Action();
    public abstract void ParaControl(float data1, float data2);
    public abstract void Death();


}
