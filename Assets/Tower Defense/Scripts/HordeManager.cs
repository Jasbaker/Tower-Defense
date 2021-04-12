using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class HordeManager : MonoBehaviour
{

  public Wave enemyWave;
  public Path enemyPath;
  public Purse enemyCoins;
  public Lives enemyLives;


  IEnumerator Start()
  {

    StartCoroutine("SpawnSmallEnemies");
    StartCoroutine("SpawnBigEnemies");

    yield break;

  }

  //pick our enemy to spawn
  //spawn it
  //wait
  IEnumerator SpawnSmallEnemies()
  {
    for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
    {

      for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfSmall; j++)
      {
        Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].smallEnemy).GetComponent<Enemy>();
        spawnedEnemy.route = enemyPath;
        spawnedEnemy.purse = enemyCoins;
        spawnedEnemy.lives = enemyLives;
        yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenSmallEnemies);

      }

      yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave); // cooldown between groups
    }


  }

  IEnumerator SpawnBigEnemies()
  {
        for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
        {

            for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfLarge; j++)
            {
                Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].bigEnemy).GetComponent<Enemy>();
                spawnedEnemy.route = enemyPath;
                spawnedEnemy.purse = enemyCoins;
                spawnedEnemy.lives = enemyLives;
                yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenLargeEnemies);

            }

            yield return new WaitForSeconds(enemyWave.coolDownBetweenLargeWave); // cooldown between groups
        }
    }
}



[Serializable]
public struct Group
{
  public GameObject smallEnemy;
  public GameObject bigEnemy;
  public int numberOfSmall;
  public int numberOfLarge;
  public float coolDownBetweenSmallEnemies;
  public float coolDownBetweenLargeEnemies;
}

[Serializable]
public struct Wave
{
  public Group[] groupsOfEnemiesInWave;
  public float coolDownBetweenSmallWave;
  public float coolDownBetweenLargeWave;
}

