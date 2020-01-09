/****************************************************
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

    private float x, z;

    private void Update()
    {
        //判断是否为本地玩家
        if (!isLocalPlayer)
        {
            return;
        }
        PlayerMove();
    }

    private void PlayerMove()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed;
        z = Input.GetAxis("Vertical") * Time.deltaTime * movSpeed;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
