using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleController : MonoBehaviour
{
    // 宣告區
    public Animator a;
    public float speed;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        a.SetFloat("Move", horizontal);

        if (horizontal != 0) {
            this.GetComponent<Transform>().position += new Vector3(0f, 0f, -horizontal * speed);
        }
    }
}
