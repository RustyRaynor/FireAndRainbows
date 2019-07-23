using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage : Stage
{
    public override SpawnableStaticObjectData GetObject()
    {
        int randomObject = Random.Range(0, 100);
        
        return (randomObject < troubleChance) ? troubleItems[Random.Range(0, troubleItems.Length)] : goodItems[Random.Range(0, goodItems.Length)];
    }

}
