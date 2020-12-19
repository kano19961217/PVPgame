using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random : MonoBehaviour  //場景隨機選擇
{
    public Image[] Item_bgs; //場景背後發亮框
    public bool can_Select;

    public void Go_start()
    {
        if (can_Select) StartCoroutine(Example(Item_bgs)); //GO按下去出發，跑馬燈亮起來
    }

    IEnumerator Example(Image[] inputimage)
    {
        can_Select = false;
        int i = 0;
        int run_factor = 2 * UnityEngine.Random.Range(2, 5) + UnityEngine.Random.Range(0, 1);
        Debug.Log(run_factor);
        while (i < run_factor)
        {
            inputimage[i % 2].GetComponent<Image>().enabled = true;
            yield return new WaitForSeconds(0.3f); //等待0.3秒
            inputimage[i % 2].GetComponent<Image>().enabled = false;
            i++;
        }
    }


        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



/* public GameObject scenes1;
    public GameObject scenes2;
    public float timer = 1; //當每秒開始

    IEnumerable Start()
    {
        for (; ; )
        {
            int x = Random.Range(0, 3);
            switch (x)
            {
                case 0:
                    Debug.Log("scenes1");
                    break;
                case 2:
                    Debug.Log("scenes2");
                    break;
            }
            yield return new WaitForSeconds(timer);
        }
    }
*/