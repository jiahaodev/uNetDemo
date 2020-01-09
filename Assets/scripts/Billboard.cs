/****************************************************
    文件：Billboard.cs
    作者：JiahaoWu
    邮箱: jiahaodev@163.ccom
    日期：2020/01/09 16:30       
    功能：血量条脚本
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
