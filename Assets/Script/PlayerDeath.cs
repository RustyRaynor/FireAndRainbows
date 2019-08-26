using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerDeath : MonoBehaviour
{
    public bool playerDead;
    public GameObject trail;
    [SerializeField]
    GameObject deathsound;
    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        trail.active = false;
        playerDead = true;
        GameObject.Find("GameManager").GetComponent<GameManager>().playerDead = true;
        deathsound.SetActive(true);
    }
}
