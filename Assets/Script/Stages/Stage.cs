using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    public int troubleChance;
    public GameObject movingTankEnemy, shooterEnemy;
    public float spawnX;
    
    public abstract float SpawnEnemies();
}
