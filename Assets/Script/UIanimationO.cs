using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIanimationO : MonoBehaviour
{
    public Animator OperationButton;  //設按鈕
    public Animator CloseButton; //設按鈕
    public Animator dialog;  //動畫對話框

    bool isHidden;
    
   Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenSettings()
    {
        
        OperationButton.SetBool("operating", true);

        //變數名稱.SetBool("變數名稱(unity Animator裡),true/false);
        //觸發按鈕動畫  //設置isHidden參數

        dialog.SetBool("operating", false);
        //動畫對話框  //設置isHidden變數名稱(unity Animator裡)參數
    }

    public void CloseSettings()
    {
        CloseButton.SetBool("operating", true);
        // OperationButton.SetBool("operating", false);
        //  CloseButton.SetBool("isHidden", false);
        //   dialog.SetBool("isHidden", false);
        //將返回按鈕並隱藏對話框
        

    }
  
}
