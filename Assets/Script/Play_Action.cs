using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Action : MonoBehaviour
{
    public Animator Anim;
    public int hp; //血量
    public float speed = 1.5f;  //走路速度
    public float rotationSpeed = 120.0f;  //旋轉速度

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>(); //動畫編輯器

    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //float translation = (Input.GetKeyDown(KeyCode.8)) * speed * Time.deltaTime;
        //鍵盤上控制上下按鍵*數度*時間

        if (translation > 0.0f)
        //假如(鍵盤按下後)
        {
            float rotation = Input.GetAxis("Horizonral") * rotationSpeed * Time.deltaTime;
            transform.Translate(0, 0, translation);
            //位置 移動  (z軸+移動)
            transform.Rotate(0, rotation, 0);
            //位置 旋轉  (Y軸做旋轉)
            
            Anim.SetBool("iswalkung", true);
            if (Input.GetKeyDown(KeyCode.Tab))
                //假如按住tab
            {
                speed = speed * 2.0f;
                Anim.SetBool("isrunning", true);
                //就會播放跑步動畫
            }
            else if (Input.GetKeyUp(KeyCode.Tab))
                //假如放開tab
            {
                speed = speed / 2.0f;
                Anim.SetBool("isrunning", false);
                //跑步動畫就會關起來
            }
        }
        else
        //假如放開按鈕上下鍵
        {
            Anim.SetBool("iswalking", false);
            //讓"走路"停下來
        }
        if (Input.GetKeyDown(KeyCode.K))
        //假如按鍵盤"K"
        {
            Anim.SetTrigger("atknow");
            //就會"攻擊"
        }
    }

    private void OnCollisionEnter(Collision collision)
        //碰撞偵測
    {
        if(collision.gameObject.tag == "atk")
            //假如碰撞  有東西攻擊
        {
            if (hp > 0) hp--;
            //就會被扣血量
            if (hp <= 0)
             //假如血量 <=0
            {
                Anim.SetTrigger("death");
                //動畫.就會撥放死亡
            }
        }
    }

}
