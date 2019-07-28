using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAI : AI
{
    public float zigzagRate, zigzagRange, moveSpeed;

    public override void SubStart(){}

    public override void Action(){
        rigidbody.velocity = -Vector2.right * GameManager.scrollAmount * moveSpeed + GameManager.scrollAmount * Vector2.up * ctrlValue * Mathf.Sin((GameManager.scrollValue + shiftValue) * zigzagRate) * zigzagRange;
    }

    public override void ParaControl(float data1, float data2)
    {
        ctrlValue = data1;
        shiftValue = data2;
    }

    public override void Death(){

    }

}
