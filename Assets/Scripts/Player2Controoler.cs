using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controoler : MonoBehaviour
{
    public Animator animator;

    // 角色生命
    public RectTransform hurtBar, healthBar;
    public int hurt, health;
    public bool healthReset;

    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 受傷血條跟上實際血條
        if (hurtBar.sizeDelta.x > healthBar.sizeDelta.x)
        {
            {
                hurtBar.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;
            }
        }

        // 死亡時觸發
        if (health < 0)
        {
            hurt = health = 100;
            healthReset = true;
        }

        // 重設生命
        if (healthReset)
        {
            healthBar.sizeDelta += new Vector2(1, 0) * Time.deltaTime * 300;
            hurtBar.sizeDelta += new Vector2(1, 0) * Time.deltaTime * 300;

            // 生命滿時停止
            if (healthBar.sizeDelta.x >= 720)
            {
                healthReset = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //角色受傷
            health -= 10;
            animator.SetTrigger("Impact");
            float a = health * 7.2f;
            healthBar.sizeDelta = new Vector2(a, healthBar.sizeDelta.y);

            Instantiate(box, other.transform.position, other.transform.rotation);
        }
    }
}
