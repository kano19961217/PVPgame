using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timeText;
    public float gameTime = 99;
    // Start is called before the first frame update
    void Start()
    {
        // 時間初始化
        timeText.text = gameTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // 遊戲倒數
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            timeText.text = Mathf.Round(gameTime).ToString();
        }
    }
}
