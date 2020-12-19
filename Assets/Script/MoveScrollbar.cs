using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class MoveScrollbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Scrollbar Scrollbar;
    public RectTransform content;
    Button[] buttons;

    public Transform pos01;
    public Transform pos02;
    float pos01_y;
    float pos02_y;
    public int columnNumber;
    public int lineNumberForShow;
    int lineNunber;
    public float step;
    public Button currentButton;
    public void InitMoveScrollbar()
    {
        buttons = content.GetComponentsInChildren<Button>();

        buttons[0].Select();

        lineNunber = (int)Mathf.Ceil(buttons.Length / (float)columnNumber);
        step = lineNumberForShow / (float)(lineNumberForShow - lineNumberForShow);

        pos01_y = pos01.position.y;
        pos02_y = pos02.position.y;
        
    }
    void Start()
    {
        Scrollbar.value = 1f;
        InitMoveScrollbar();
    }

    public void GetButton(Button button)
    {
        currentButton = button;
        float y = button.transform.position.y;

        if (y>pos01_y)
        {
            Scrollbar.value += step;
        }
        if (y > pos02_y)
        {
            Scrollbar.value -= step;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
