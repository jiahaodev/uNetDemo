﻿/****************************************************
    文件：PlayerController.cs
    作者：JiahaoWu
    邮箱: jiahaodev@163.ccom
    日期：2020/01/09 15:00       
    功能：玩家控制脚本
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float rotSpeed = 150.0f;
    public float movSpeed = 3.0f;
    public GameObject bulletPrefab; //子弹预制体
    public Transform bulletSpawn;  //子弹生成位置

    private float x, z;

    private void Update()
    {
        //判断是否为本地玩家
        if (!isLocalPlayer)
        {
            return;
        }
        PlayerMove();
        Fire();
    }

    //玩家移动检测
    private void PlayerMove()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed;
        z = Input.GetAxis("Vertical") * Time.deltaTime * movSpeed;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    //玩家开火检测
    private void Fire() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //生成子弹
            var bullet = Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
            //给子弹加速度
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
            //销毁子弹
            Destroy(bullet,2.0f);
        }
    }

    //NetworkBehaviour接口重写
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
