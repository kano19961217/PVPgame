using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour  //血條程式
{
    public int startingHealth = 100;  //初始血量有多少(還沒變化前的血量\)
    public Slider healthSlider; //血條
    public static int currentHealth;  //目前血量 (可能被減 也有可能被增加)
    
  
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = startingHealth;  //血條.最大值 = 原始血量(=100)

        if (currentHealth <=0)  //如果 你的血量<=0  =角色已經死亡=  //重新玩
        {
            healthSlider.value = startingHealth;  //畫面血條(healthSlider)呈現是全滿
            currentHealth = startingHealth;  //因重新玩所以 目前血量(currentHealth)會回復成初始血量(startingHealth)
        }
        else   //否則
        {
            healthSlider.value = startingHealth;
        }
       
    }

    public void TakeDamage(int amount) //被攻擊  //被攻擊(TakeDamage)之後受到的量(amount) 
    {
        currentHealth -= amount;  //目前血量(currentHealth) 扣血
        healthSlider.value = currentHealth;//血條的量(value)=目前血條
    }
}
