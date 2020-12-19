using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIM2 : MonoBehaviour  //轉換場景
{
  
    public void StartGame()
    {
        SceneManager.LoadScene("ReadScene");  //轉換場景
    }

}



