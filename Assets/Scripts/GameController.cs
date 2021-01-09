using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // 0: 遊戲暫停, 1: 開始前倒數, 2: 遊戲開始
    public int  status = 0;
    public Text timeText;
    public float gameTime = 99;

    public GameObject option;
    public GameObject countText;
    public float count = 0;
    public GameObject fight;

    public string[] numArray;
    // Start is called before the first frame update
    void Start()
    {
        count = 3;
        // 時間初始化
        countText.GetComponent<Text>().text = count.ToString();
        timeText.text = gameTime.ToString();
        status = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == 1)
        {
            count -= Time.deltaTime;
            int i = (int) Mathf.Round(count);

            if (i >= 0)
            {
                countText.GetComponent<Text>().text = numArray[i];
            }
            if (count <= -1)
            {
                status = 2;
            }
            else if (count <= 0)
            {
                countText.SetActive(false);
            }

        }

        // 遊戲倒數
        if (gameTime > 0 && status == 2)
        {
            gameTime -= Time.deltaTime;
            timeText.text = Mathf.Round(gameTime).ToString();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (option.active)
            {
                option.SetActive(false);
                status = 2;
            }
            else
            {
                option.SetActive(true);
                status = 0;
            }
        }
    }

    public void BackHome()
    {
        Debug.Log("BackHome");
        SceneManager.LoadScene("StartGame");  //返回大廳
    }
}
