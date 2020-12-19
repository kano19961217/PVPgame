using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen; //取得進度條版面
    public Slider slider;  //進度條的進度
    public Text progressText; //顯示進度條文字
    public GameObject Figure; //進度條上圖案
    private Vector3 macaPos;
    private float macaMove;
    private float speed = 1.5f; //速度
    public float progress = 0.0f; //進度
    //public GameObject.transform.position = move;
    

    int displayProgress = 0 ; //顯示進度
    int toProgress = 0; //進度
  

    [Tooltip("GameScene")] 
    public string nextSceneName;
    
   
    
    void Update()
    {
        if (progress < 1.0f)  //假如進度(progress)<1.0f
        {
            progress += 0.2f * Time.deltaTime;  //  進度每秒加0.2f
            slider.value = progress;   //進度條的進度=progress
            displayProgress = Convert.ToInt32(slider.value * 100f); //進度上數字伏點變整數  //讓數字變整數(Convert.ToInt32)
            progressText.text = displayProgress.ToString() + "%"; //進度數字以%出現

           /* Vector3 move = Figure.transform.position;
            Figure.transform.position += Figure.transform.forward * Time.deltaTime * 0.2f;
            move = new Vector3((macaPos.x + (macaMove *  * 0.2f)), macaPos.y, macaPos.z);*/

            if (displayProgress >= 100)   //假如進度 >=100
            { 
               SceneManager.LoadScene("GameScene");  //就會轉換到下個場景
            } 
            //setLoading(progress);
        }
    }

}
/*private IEnumerator LoadAsync(int i)
    {

       // AsyncOperation operation = SceneManager.LoadSceneAsync(i); //載入場景

        loadingScreen.SetActive(true);   //獲得進度加載參數 並顯示進度情況

        while (!operation.isDone == false)
        {
#if UNITY_EDITOR

            
            //SetLoadingPerce tage(operation.progress * 100);
            float progress = Mathf.Clamp01(operation.progress / 0.9f);  //進度條0.9加載成功
#endif
            slider.value = progress; //進度條的進度
            progressText.text = (progress * 100f).ToString() + "%";  //動態顯示進度值
            yield return null;
        }

    }
  /* private void setLoading(float percent)
    {
        //load_line.transform.localScale = new Vector3((percent * 0.01f), 1, 1);
        //load_text.text = percent.ToString() + " % ";
        //圖案移動
         Figure.transform.position =
        new Vector3((macaPos.x + (macaMove * percent * 0.01f)), macaPos.y, macaPos.z);
    }*/
