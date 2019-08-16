using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    [SerializeField][Tooltip("Max Threat Control")]
    public int currentThreat, maxThreat, incrementRate = 2;

    [System.Serializable]
    public struct EnemyUnit
    {
        public bool tire2;
        public GameObject unit;
        public Vector2 preferedPoint;
    }

    public EnemyUnit[] enemyUnitSet;
    public EnemyUnit stageBoss;
    public int maxWaves = 20;
    public float spawnX;
    
    public abstract void SpawnEnemies();
    public abstract void SpawnBoss();
}
