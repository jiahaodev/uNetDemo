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

public class Health : MonoBehaviour
{
    public const int MAX_HEALTH = 100;  //���Ѫ��  

    public RectTransform healthBar;

    private int currentHealth = MAX_HEALTH;

    /// <summary>
    /// ��������ֵ
    /// </summary>
    /// <param name="amount">�˺�ֵ</param>
    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.LogFormat("{0}������......",gameObject.name);
        }
        healthBar.sizeDelta = new Vector2(currentHealth,healthBar.sizeDelta.y);
    }

}
