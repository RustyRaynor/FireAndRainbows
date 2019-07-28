using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : MonoBehaviour
{
    protected bool active;
    protected int health;
    protected Rigidbody2D rigidbody;
    public float ctrlValue, shiftValue, limitWorldX, destroyOffset;

    void Start()
    {
        health = 100;
        active = true;
        rigidbody = GetComponent<Rigidbody2D>();
        limitWorldX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        SubStart();
    }

    void Update()
    {
        if(health > 0)Action();
        else if(active) Death();
        if(transform.position.x + destroyOffset < -limitWorldX)Destroy(gameObject);
    }

    public abstract void SubStart();
    public abstract void Action();
    public abstract void ParaControl(float data1, float data2);
    public abstract void Death();


}
