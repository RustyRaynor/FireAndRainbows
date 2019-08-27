using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : Stage
{
    [SerializeField]new string name;
    Vector3 birthPlace;
    public override void SpawnEnemies()
    {
        EnemyUnit pickedEnemy;

        if(currentThreat < maxThreat)
        {   
            pickedEnemy = enemyUnitTire1[Random.Range(0, enemyUnitTire1.Length)];
        }
        else
        {
            int type = Random.Range(0,10);
            if(type < 5){
                pickedEnemy = enemyUnitTire1[Random.Range(0, enemyUnitTire1.Length)];
            }

            else{
                pickedEnemy = enemyUnitTire2[Random.Range(0, enemyUnitTire2.Length)];
            }
        }

        float segX = Screen.width/100;
        float segY = Screen.height/100;
        birthPlace = Vector3.zero;
        birthPlace.z = 1;
        birthPlace.x = segX * pickedEnemy.preferedPoint.x;
        birthPlace.y = segY * pickedEnemy.preferedPoint.y;
        Instantiate(pickedEnemy.unit, Camera.main.ScreenToWorldPoint(birthPlace), Quaternion.identity, GameManager.enemyHolder);

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
        Instantiate(stageBoss.unit, Camera.main.ScreenToWorldPoint(birthPlace), Quaternion.identity, GameManager.enemyHolder);

    }

}
