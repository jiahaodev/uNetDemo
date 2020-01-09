/****************************************************
    �ļ���Health.cs
    ���ߣ�JiahaoWu
    ����: jiahaodev@163.ccom
    ���ڣ�2020/01/09 16:13       
    ���ܣ����Ѫ������ű�
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public bool destroyOnDeath;  // ��ҽ�ɫ �� ���˵��ж�

    public const int MAX_HEALTH = 100;  //���Ѫ��  

    public RectTransform healthBar;
    [SyncVar(hook = "OnChangeHealth")] //ͬ������
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
    /// ��������ֵ
    /// </summary>
    /// <param name="amount">�˺�ֵ</param>
    public void TakeDamage(int amount) {
        //if (!isServer)
        //{
        //    return;
        //}

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (destroyOnDeath) //����ǵ���
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.LogFormat("{0}������......", gameObject.name);
                if (!isServer)
                {
                    return;
                }
                RpcRespawn();//Rpc�ӿ�Ӧ���з���������
            }

        }
        //healthBar.sizeDelta = new Vector2(currentHealth,healthBar.sizeDelta.y);
    }


    //SyncVar�����仯 �ص��ӿ�
    private void OnChangeHealth(int health) {
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    //�ڷ�����ϱ����ã��ڿͻ�����ִ�У���Commands�෴��
    /*
     * �����ǵĽ̳���ͻ��˿��Ʊ���Player ��λ�á�������ΪPlayer���жԿͻ��˵ı���Ȩ�ޡ����������͸����еĿͻ��˽�Client Player��ΪClientRpc���ò��ƶ�����ʼλ�á���ΪPlayer����NetworkTransform��������пͻ��˶���ͬ����λ�á�
     * [���] �ɱ���ɱ��������� ����λ����Ч����ͬ�������пͻ��ˡ�
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
