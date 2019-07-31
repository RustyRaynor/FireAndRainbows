using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage : Stage
{
    Vector3 birthPlace;
    public override float SpawnEnemies()
    {
        float segX = Screen.width/100;
        float segY = Screen.height/100;
        int enemyType = Random.Range(0, enemyUnitSet.Length);
        birthPlace = Vector3.zero;
        birthPlace.x = segX * enemyUnitSet[enemyType].preferedPoint.x;
        birthPlace.y = segY * enemyUnitSet[enemyType].preferedPoint.y;
        Instantiate(enemyUnitSet[enemyType].unit, birthPlace, Quaternion.identity);
        return enemyUnitSet[enemyType].waitTime;

    }

}
