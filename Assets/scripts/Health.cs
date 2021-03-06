/****************************************************
    文件：Health.cs
    作者：JiahaoWu
    邮箱: jiahaodev@163.ccom
    日期：2020/01/09 16:13       
    功能：玩家血量管理脚本
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public bool destroyOnDeath;  // 玩家角色 与 敌人的判断

    public const int MAX_HEALTH = 100;  //最大血量  

    public RectTransform healthBar;
    [SyncVar(hook = "OnChangeHealth")] //同步变量
    private int currentHealth = MAX_HEALTH;
    private NetworkStartPosition[] spawnPoints;

    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    /// <summary>
    /// 减少生命值
    /// </summary>
    /// <param name="amount">伤害值</param>
    public void TakeDamage(int amount) {
        //if (!isServer)
        //{
        //    return;
        //}

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (destroyOnDeath) //如果是敌人
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.LogFormat("{0}牺牲了......", gameObject.name);
                if (!isServer)
                {
                    return;
                }
                RpcRespawn();//Rpc接口应该有服务器调用
            }

        }
        //healthBar.sizeDelta = new Vector2(currentHealth,healthBar.sizeDelta.y);
    }


    //SyncVar变量变化 回调接口
    private void OnChangeHealth(int health) {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    //在服务端上被调用，在客户端上执行，与Commands相反。
    /*
     * 在我们的教程里，客户端控制本地Player 的位置。这是因为Player享有对客户端的本地权限。服务器发送给所有的客户端将Client Player作为ClientRpc调用并移动到开始位置。因为Player具有NetworkTransform组件，所有客户端都会同步此位置。
     * [因此] 由被击杀的玩家主动 “归位”，效果会同步到所有客户端。
     */
    [ClientRpc]
    private void RpcRespawn() {
        if (isLocalPlayer)
        {
           Vector3 spawnPoint = Vector3.zero;
            if (spawnPoints!=null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;

            currentHealth = MAX_HEALTH;
        }
    }

}
