using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIanimation : MonoBehaviour
{
    public Animator SetButton;  //設按鈕
    //public Animator OperationButton;  //設按鈕
    public Animator dialog; //設動畫對話框
    public Animator CloseButton; //設按鈕 

    bool isHidden;

    Animator anim;

    // 使用此函数进行初始化
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update

    public void OpenSettings()
    {
       SetButton.SetBool("isHidden", true); 
       //OperationButton.SetBool("Bool", true);

        //變數名稱.SetBool("變數名稱(unity Animator裡),true/false);
        //觸發按鈕動畫  //設置isHidden參數

        dialog.SetBool("isHidden", false);
        //動畫對話框  //設置isHidden變數名稱(unity Animator裡)參數
    }

    public void CloseSettings()
    {
        //anim.SetBool("isHidden", false);
        CloseButton.SetBool("isHidden", true);
        // OperationButton.SetBool("Bool", false);
        //  CloseButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
        //將返回按鈕並隱藏對話框

    }
    /*public void OnBtnShowClick()
    {
        UIManager.Instance.ShowPanel("CloseButton");
    }*/

    /*public void QuitGame()
    {
        Application.Quit();
    }*/

}
