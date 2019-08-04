using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldozeAI : AI
{
    public float moveSpeed, exitSpeed, targetX, stayDuration, exitTime;
    public AIState currentState;
    public int fightCount;

    public enum AIState
    {
        entry,
        wait,
        leave
    }

    public override void SubStart(){
       targetX = Camera.main.ScreenToWorldPoint(new Vector2(8 * Screen.width/9 , 0)).x;
    }

    public override void Action(){

        if(currentState == AIState.entry)
        {
            rigidbody.velocity = -Vector2.right * GameManager.scrollAmount * moveSpeed;
            float currentX = transform.position.x;
            if(currentX < targetX)
            {
                currentState = AIState.wait;
                exitTime = GameManager.scrollValue + stayDuration;
                rigidbody.velocity *= 0;
            }
        }

        else if(currentState == AIState.wait)
        {

            if(GameManager.scrollValue > exitTime)
            {
                currentState = AIState.leave;
            }
            
        }

        else if(currentState == AIState.leave)
        {
            rigidbody.velocity = -Vector2.right * GameManager.scrollAmount * exitSpeed;
        }

    }

    public override void ParaControl(float data1, float data2)
    {
        ctrlValue = data1;
        shiftValue = data2;
    }

    public override void Death(){

    }

}
