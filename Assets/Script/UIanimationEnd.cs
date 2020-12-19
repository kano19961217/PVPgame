using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIanimationEnd : MonoBehaviour
{
    public Animator EndButton;  //設按鈕
    public Animator dialog; //設動畫對話框

    // Start is called before the first frame update
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
        EndButton.SetBool("isHidden2", true);
        //OperationButton.SetBool("Bool", true);

        //變數名稱.SetBool("變數名稱(unity Animator裡),true/false);
        //觸發按鈕動畫  //設置isHidden參數

        dialog.SetBool("isHidden2", false);
        //動畫對話框  //設置isHidden變數名稱(unity Animator裡)參數
    }
    public void CloseSettings()
    {
        //anim.SetBool("isHidden", false);
        EndButton.SetBool("isHidden2", true);
        // OperationButton.SetBool("Bool", false);
        //  CloseButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden2", true);
        //將返回按鈕並隱藏對話框

    }


    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            EndButton.SetActive(true);
        }
    }*/
    /*public void StartGame()
    {
        SceneManager.LoadScene("Scene-1");
    }*/

    public void QuitGame()
    {
        Application.Quit();
    }
}
