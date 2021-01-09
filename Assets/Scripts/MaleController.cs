﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleController : MonoBehaviour
{
    // 宣告區
    public float speed;
    public bool isGround = true;
    public int hitCount = 0;

    //角色動畫
    public Animator anim;

    //// 角色生命
    // 血量 UI
    public RectTransform hurtBar, healthBar;
    // 血量
    public int hurt, health;

    //// 角色必殺技
    public GameObject skill;
    // 大招位置
    public Transform skillTransform;
    // 能量UI 
    public RectTransform skillBar;
    // 能量點數
    public int skillPoint = 0;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.status == 2)
        {
            Move();
            SkillBar();
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // 角色移動
        if (horizontal != 0)
        {
            anim.SetFloat("Move", Mathf.Round(horizontal));
            this.GetComponent<Transform>().position += new Vector3(0f, 0f, -horizontal * speed);
        }

        // 角色跳躍
        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            anim.SetTrigger("Jump");
            this.GetComponent<Rigidbody>().AddForce(0, 150f, 0);
            isGround = false;
        }

        ///// TODO 
        // 測試扣血用
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //角色受傷
            health -= 10;
            float a = health * 7.2f;
            healthBar.sizeDelta = new Vector2(a, healthBar.sizeDelta.y);
        }
        */

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (skillPoint >= 100)
            {
                //施放大招
                anim.SetTrigger("Skill");
                //2秒後施放
                Invoke("Skill", 2f);

                skillPoint = 0;
            }
        }

        // 受傷血條跟上實際血條
        if (hurtBar.sizeDelta.x > healthBar.sizeDelta.x)
        {
            {
                hurtBar.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 100;
            }

        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetInteger("Heavy", 1);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_heavy") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.50f)
            {
                anim.SetInteger("Heavy", 0);
            }

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetInteger("Attack", 1);

            // 設定 連擊 Hit
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_combo01") && hitCount == 0 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.50f)
            {
                hitCount = 1;
                anim.SetInteger("Attack", 2);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_combo02") && hitCount == 1 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.50f)
            {
                hitCount = 2;
                anim.SetInteger("Attack", 3);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_combo03") && hitCount == 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.50f)
            {
                hitCount = 0;
                anim.SetInteger("Attack", 0);
            }

        }

        // 判斷攻擊動畫結束
        if ((anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_combo01") ||
             anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_combo02") ||
             anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_combo03") ||
             anim.GetCurrentAnimatorStateInfo(0).IsName("Male_attack_heavy")) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            Debug.Log("攻擊結束");
            hitCount = 0;
            anim.SetInteger("Attack", 0);
            anim.SetInteger("Heavy", 0);
        }
    }

    void SkillBar()
    {
        float a = skillPoint * 4f;
        skillBar.sizeDelta = new Vector2(a + 10f, skillBar.sizeDelta.y);
    }

    void Skill()
    {
        Instantiate(skill, skillTransform.position, skillTransform.rotation);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Plane")
        {
            isGround = true;
        }
    }
}
