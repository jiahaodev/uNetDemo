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

public class Health : MonoBehaviour
{
    public const int MAX_HEALTH = 100;  //最大血量  

    public RectTransform healthBar;

    private int currentHealth = MAX_HEALTH;

    /// <summary>
    /// 减少生命值
    /// </summary>
    /// <param name="amount">伤害值</param>
    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.LogFormat("{0}牺牲了......",gameObject.name);
        }
        healthBar.sizeDelta = new Vector2(currentHealth,healthBar.sizeDelta.y);
    }

}
