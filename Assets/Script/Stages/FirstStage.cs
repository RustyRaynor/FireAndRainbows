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

    public override float SpawnEnemies()
    {
        float y1, y2, y3, y4, y5, y6;
        float x1, x2, x3, x4, x5, x6;
        Vector3 pos1, pos2, pos3, pos4, pos5, pos6;
        float segX = Screen.width/10;
        spawnX = segX + Screen.width;
        float segY = Screen.height/10;
        int enemyType = Random.Range(0, 100)/10;

        switch(enemyType)
        {
            // make one bounci
            case 0 : 
            y1 = segY * Random.Range(3, 8);
            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, y1, 1));
            Instantiate(movingTankEnemy, pos1, Quaternion.identity);
            
            return 10;

            // make two bouncies top and bottom
            case 1 : 
            y1 = segY * 2;
            y2 = segY * 8;
            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, y1, 1));
            pos2 = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, y2, 1));
            Instantiate(movingTankEnemy, pos1, Quaternion.identity);
            AI newAI = Instantiate(movingTankEnemy, pos2, Quaternion.identity).GetComponent<AI>();
            newAI.ParaControl(-1,0);
            
            return 20;

            // make a snake
            case 2 : 
            y1 = segY * Random.Range(3, 8);

            x1 = spawnX;
            x2 = spawnX + segX;
            x3 = spawnX + segX * 2;
            x4 = spawnX + segX * 3;
            x5 = spawnX + segX * 4;
            x6 = spawnX + segX * 5;

            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(x1, y1, 1));
            pos2 = Camera.main.ScreenToWorldPoint(new Vector3(x2, y1, 1));
            pos3 = Camera.main.ScreenToWorldPoint(new Vector3(x3, y1, 1));
            pos4 = Camera.main.ScreenToWorldPoint(new Vector3(x4, y1, 1));
            pos5 = Camera.main.ScreenToWorldPoint(new Vector3(x5, y1, 1));
            pos6 = Camera.main.ScreenToWorldPoint(new Vector3(x6, y1, 1));

            Instantiate(movingTankEnemy, pos1, Quaternion.identity).GetComponent<AI>().ParaControl(1,0);
            Instantiate(movingTankEnemy, pos2, Quaternion.identity).GetComponent<AI>().ParaControl(1,2);
            Instantiate(movingTankEnemy, pos3, Quaternion.identity).GetComponent<AI>().ParaControl(1,4);
            Instantiate(movingTankEnemy, pos4, Quaternion.identity).GetComponent<AI>().ParaControl(1,6);
            Instantiate(movingTankEnemy, pos5, Quaternion.identity).GetComponent<AI>().ParaControl(1,8);
            Instantiate(movingTankEnemy, pos6, Quaternion.identity).GetComponent<AI>().ParaControl(1,10);
            
            return 20;

            // make / enemies
            case 3 : 
            y1 = segY * 3;
            y2 = segY * 4;
            y3 = segY * 5;
            y4 = segY * 6;
            y5 = segY * 7;
            y6 = segY * 8;

            x1 = spawnX;
            x2 = spawnX + segX;
            x3 = spawnX + segX * 2;
            x4 = spawnX + segX * 3;
            x5 = spawnX + segX * 4;
            x6 = spawnX + segX * 5;

            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(x1, y1, 1));
            pos2 = Camera.main.ScreenToWorldPoint(new Vector3(x2, y2, 1));
            pos3 = Camera.main.ScreenToWorldPoint(new Vector3(x3, y3, 1));
            pos4 = Camera.main.ScreenToWorldPoint(new Vector3(x4, y4, 1));
            pos5 = Camera.main.ScreenToWorldPoint(new Vector3(x5, y5, 1));
            pos6 = Camera.main.ScreenToWorldPoint(new Vector3(x6, y6, 1));

            Instantiate(movingTankEnemy, pos1, Quaternion.identity).GetComponent<AI>().ParaControl(1,0);
            Instantiate(movingTankEnemy, pos2, Quaternion.identity).GetComponent<AI>().ParaControl(1,2);
            Instantiate(movingTankEnemy, pos3, Quaternion.identity).GetComponent<AI>().ParaControl(1,4);
            Instantiate(movingTankEnemy, pos4, Quaternion.identity).GetComponent<AI>().ParaControl(1,6);
            Instantiate(movingTankEnemy, pos5, Quaternion.identity).GetComponent<AI>().ParaControl(1,8);
            Instantiate(movingTankEnemy, pos6, Quaternion.identity).GetComponent<AI>().ParaControl(1,10);
            
            return 20;

            // make \ enemies
            case 4: 
            y1 = segY * 8;
            y2 = segY * 7;
            y3 = segY * 6;
            y4 = segY * 5;
            y5 = segY * 4;
            y6 = segY * 3;

            x1 = spawnX;
            x2 = spawnX + segX;
            x3 = spawnX + segX * 2;
            x4 = spawnX + segX * 3;
            x5 = spawnX + segX * 4;
            x6 = spawnX + segX * 5;

            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(x1, y1, 1));
            pos2 = Camera.main.ScreenToWorldPoint(new Vector3(x2, y2, 1));
            pos3 = Camera.main.ScreenToWorldPoint(new Vector3(x3, y3, 1));
            pos4 = Camera.main.ScreenToWorldPoint(new Vector3(x4, y4, 1));
            pos5 = Camera.main.ScreenToWorldPoint(new Vector3(x5, y5, 1));
            pos6 = Camera.main.ScreenToWorldPoint(new Vector3(x6, y6, 1));

            Instantiate(movingTankEnemy, pos1, Quaternion.identity).GetComponent<AI>().ParaControl(1,0);
            Instantiate(movingTankEnemy, pos2, Quaternion.identity).GetComponent<AI>().ParaControl(1,2);
            Instantiate(movingTankEnemy, pos3, Quaternion.identity).GetComponent<AI>().ParaControl(1,4);
            Instantiate(movingTankEnemy, pos4, Quaternion.identity).GetComponent<AI>().ParaControl(1,6);
            Instantiate(movingTankEnemy, pos5, Quaternion.identity).GetComponent<AI>().ParaControl(1,8);
            Instantiate(movingTankEnemy, pos6, Quaternion.identity).GetComponent<AI>().ParaControl(1,10);
            
            return 20;

            // make < enemies
            case 5: 
            y1 = segY * 8;
            y2 = segY * 7;
            y3 = segY * 6;
            y4 = segY * 5;
            y5 = segY * 4;
            y6 = segY * 3;

            x1 = spawnX + segX * 2;
            x2 = spawnX + segX;
            x3 = spawnX;
            x4 = spawnX;
            x5 = spawnX + segX;
            x6 = spawnX + segX * 2;

            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(x1, y1, 1));
            pos2 = Camera.main.ScreenToWorldPoint(new Vector3(x2, y2, 1));
            pos3 = Camera.main.ScreenToWorldPoint(new Vector3(x3, y3, 1));
            pos4 = Camera.main.ScreenToWorldPoint(new Vector3(x4, y4, 1));
            pos5 = Camera.main.ScreenToWorldPoint(new Vector3(x5, y5, 1));
            pos6 = Camera.main.ScreenToWorldPoint(new Vector3(x6, y6, 1));

            Instantiate(movingTankEnemy, pos1, Quaternion.identity).GetComponent<AI>().ParaControl(-1,9);
            Instantiate(movingTankEnemy, pos2, Quaternion.identity).GetComponent<AI>().ParaControl(-1,3);
            Instantiate(movingTankEnemy, pos3, Quaternion.identity).GetComponent<AI>().ParaControl(-1,0);
            Instantiate(movingTankEnemy, pos4, Quaternion.identity).GetComponent<AI>().ParaControl(1,0);
            Instantiate(movingTankEnemy, pos5, Quaternion.identity).GetComponent<AI>().ParaControl(1,3);
            Instantiate(movingTankEnemy, pos6, Quaternion.identity).GetComponent<AI>().ParaControl(1,9);
            
            return 20;

            // make one shooter
            case 6 : 
            y1 = segY * Random.Range(3, 8);
            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, y1, 1));
            Instantiate(shooterEnemy, pos1, Quaternion.identity);
            
            return 30;

            case 7 : 
            y1 = segY * 2;
            y2 = segY * 8;
            pos1 = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, y1, 1));
            pos2 = Camera.main.ScreenToWorldPoint(new Vector3(spawnX, y2, 1));
            Instantiate(shooterEnemy, pos1, Quaternion.identity);
            Instantiate(shooterEnemy, pos2, Quaternion.identity);


            return 60;

            default :
            return 0;

        }

    }

}
