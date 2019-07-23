using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public struct SpawnableStaticObjectData
    {
        public GameObject spawnableObject;
        public float intervel;
    }

public abstract class Stage : MonoBehaviour
{
    public int troubleChance;
    public SpawnableStaticObjectData[] troubleItems;
    public SpawnableStaticObjectData[] goodItems;
    
    public abstract SpawnableStaticObjectData GetObject(); 
}
