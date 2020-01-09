/****************************************************
    文件：Bullet.cs
    作者：JiahaoWu
    邮箱: jiahaodev@163.ccom
    日期：2020/01/09 16:10       
    功能：子弹脚本
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.LogFormat("打到{0}了，哈哈", collision.gameObject.name);
        var hit = collision.gameObject;
        if (hit.tag == "Gun") {
            return;
        }
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }

        //销毁子弹
        Destroy(gameObject);
    }
}
