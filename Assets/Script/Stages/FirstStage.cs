using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage : Stage
{
    Vector3 birthPlace;
    public override void SpawnEnemies()
    {
        EnemyUnit pickedEnemy = enemyUnitSet[Random.Range(0, enemyUnitSet.Length)];
        if(currentThreat < maxThreat && pickedEnemy.tire2)
        {   Debug.Log("Changed...");
            bool changed = false;

                while(!changed){
                    pickedEnemy = enemyUnitSet[Random.Range(0, enemyUnitSet.Length)];
                    if(!pickedEnemy.tire2)changed = true;
                }
        }
        else
        {
            while(pickedEnemy.tire2){
                pickedEnemy = enemyUnitSet[Random.Range(0, enemyUnitSet.Length)];
            }
        }

        float segX = Screen.width/100;
        float segY = Screen.height/100;
        birthPlace = Vector3.zero;
        birthPlace.z = 1;
        birthPlace.x = segX * pickedEnemy.preferedPoint.x;
        birthPlace.y = segY * pickedEnemy.preferedPoint.y;
        Instantiate(pickedEnemy.unit, Camera.main.ScreenToWorldPoint(birthPlace), Quaternion.identity);

        currentThreat += incrementRate;
        if(currentThreat >= maxThreat) currentThreat = maxThreat;

    }

    public override void SpawnBoss()
    {
        float segX = Screen.width/100;
        float segY = Screen.height/100;
        birthPlace = Vector3.zero;
        birthPlace.z = 1;
        birthPlace.x = segX * stageBoss.preferedPoint.x;
        birthPlace.y = segY * stageBoss.preferedPoint.y;
        Instantiate(stageBoss.unit, Camera.main.ScreenToWorldPoint(birthPlace), Quaternion.identity);

    }

}
