using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Shiny : MonoBehaviour  //隨機功能
{
    public Image[] Item_bgs; //場景背後發亮框
    public bool can_Select; //控制是否能開始Select的開關


    private void Start()
    {
        StartCoroutine(Example(Item_bgs));
    }

    public void Go_start()
    {
        if (can_Select) StartCoroutine(Example(Item_bgs)); //GO按下去出發，跑馬燈亮起來
    }

    IEnumerator Example(Image[] inputimage)
    {
        can_Select = false;
        int i = 0;
        int run_factor = 2 * UnityEngine.Random.Range(2, 9) + UnityEngine.Random.Range(0, 2);
        Debug.Log(run_factor);
        while (i < run_factor)
        {
            inputimage[i % 3].GetComponent<Image>().enabled = true;  //[i % 數字] 數字=幾個動態
            yield return new WaitForSeconds(0.3f); //等待0.3秒
            if (i != run_factor-1) inputimage[i % 3].GetComponent<Image>().enabled = false;
            i++;
        }
    }
}
