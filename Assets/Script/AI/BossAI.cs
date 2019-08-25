using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    enum AIState
    {
        entry,
        fight,
        die
    }
    public GameObject bullet, FirePoint, explossionObject;
    public AnimationClip[] allAnimations;
    public float speed, stopingPoint, health;
    Animation animation;
    AIState currentState;
    Rigidbody2D rigidbody;

    void Start()
    {
            rigidbody = GetComponent<Rigidbody2D>();
            animation = GetComponent<Animation>();
            stopingPoint = Camera.main.ScreenToWorldPoint(new Vector2(7 * Screen.width/9 , 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == AIState.entry)
        {
            rigidbody.velocity = -Vector2.right * speed * GameManager.scrollAmount;
            if(transform.position.x < stopingPoint)
            {
                currentState = AIState.fight;
                rigidbody.velocity *= 0;
            }
        }
        else if(currentState == AIState.fight)
        {
            
            if(!animation.isPlaying)
            {
                animation.clip = allAnimations[Random.Range(0, allAnimations.Length)];
                animation.Play();
            }

        }

        if(health <= 0)
        {
            animation.Play();
            Destroy(Instantiate(bullet, FirePoint.transform.position, Quaternion.identity), 10);
            GameManager.canSpawn = true;

            GameObject.Find("GameManager").GetComponent<Statemanager>().bossDefeated = true ;

            Destroy(this.gameObject);
        }

        if(GameManager.canStop)
        {
            animation.Stop();
        }

    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if(other.CompareTag("PlayerBullet"))
            {
                health -= 10;
            }
    }

}
