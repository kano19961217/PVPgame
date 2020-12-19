using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text HealthText;
    public static int HealthCurrent;  //目前血量
    public  int HealthMax; //最大值血量

    public Image healthBar;

        //改變ui效果
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>(); 
        HealthCurrent = HealthMax;     //當前血量=最大值
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        HealthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
