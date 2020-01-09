/****************************************************
    文件：EnemySpawner.cs
    作者：JiahaoWu
    邮箱: jiahaodev@163.ccom
    日期：2020/01/09 17:10       
    功能：敌人生成器
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemy;

    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            float x = Random.Range(-8.0f,8.0f);
            float z = Random.Range(0, 180);
            var spawnPosition = new Vector3(x,0f,x);
            var spawnRotation = Quaternion.Euler(0f,z,0f);
            var enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy); //服务器生成敌人
        }
    }
}
