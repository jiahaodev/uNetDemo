/****************************************************
    �ļ���Billboard.cs
    ���ߣ�JiahaoWu
    ����: jiahaodev@163.ccom
    ���ڣ�2020/01/09 16:30       
    ���ܣ�Ѫ�����ű�
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
