using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour  //轉換場景
{
    public static object Instance { get; internal set; }

    /* private string sceneName;
void ChangeScene()
{
SceneManager.LoadScene(1);
sceneName = SceneManager.
}*/

    public void StartGame()
    {
        SceneManager.LoadScene("DemoScene_Classic_Trees");  //轉換角色場景
    }

   
}
