using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : AI
{
    public float maxFire, zigzagRate, zigzagRange, moveSpeed, exitSpeed, targetX;
    public float fireRate;
    public float nextFireFrequency;
    float nextFireInterval, fireCount;
    [SerializeField]GameObject bullet;
    [SerializeField]Transform firePoint;
    public AIState currentState;
    public int fightCount;

    public enum AIState
    {
        entry,
        fight,
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
                currentState = AIState.fight;
                rigidbody.velocity *= 0;
            }
        }

        else if(currentState == AIState.fight)
        {

            rigidbody.velocity = GameManager.scrollAmount * Vector2.up * ctrlValue * Mathf.Sin((GameManager.scrollValue + shiftValue) * zigzagRate) * zigzagRange;
            if(GameManager.scrollValue > nextFireInterval)
            {
                fireCount++;
                nextFireInterval = GameManager.scrollValue + nextFireFrequency;
                Instantiate(bullet,firePoint.position, Quaternion.identity);
            }
            if(fireCount > maxFire)
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
