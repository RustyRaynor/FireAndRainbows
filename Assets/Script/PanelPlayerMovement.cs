using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPlayerMovement : MonoBehaviour
{
    public GameObject player;
    PlayerMovement moveScript;
    PlayerShoot shootScript;

    private void Start()
    {
        moveScript = player.GetComponent<PlayerMovement>();
        shootScript = player.GetComponent<PlayerShoot>();
    }

    public void Fly()
    {
        moveScript.AliveMovement();
    }

    public void Shoot()
    {
        shootScript.Shoot();
    }
}
