/****************************************************
    �ļ���Bullet.cs
    ���ߣ�JiahaoWu
    ����: jiahaodev@163.ccom
    ���ڣ�2020/01/09 16:10       
    ���ܣ��ӵ��ű�
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.LogFormat("��{0}�ˣ�����", collision.gameObject.name);
        var hit = collision.gameObject;
        if (hit.tag == "Gun") {
            return;
        }
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        //�����ӵ�
        Destroy(gameObject);
    }
}
