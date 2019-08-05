using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] GameObject explosion;
    [SerializeField] bool instaSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            if(instaSpawn)GameManager.canSpawn = true;
            GameObject.Find("GameManager").GetComponent<ScoreCounter>().enemyScore += 50;
            Vector3 position = collision.gameObject.transform.position;
            Destroy(Instantiate(explosion, position, collision.gameObject.transform.rotation), 3);
            Destroy(this.gameObject);
        }
    }
}
