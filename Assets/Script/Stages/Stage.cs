using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    [System.Serializable]
    public struct EnemyUnit
    {
        public GameObject unit;
        public Vector2 preferedPoint;
        public float waitTime;
    }

    public EnemyUnit[] enemyUnitSet;
    public float spawnX;
    
    public abstract float SpawnEnemies();
}
