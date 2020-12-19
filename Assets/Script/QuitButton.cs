using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button EndButton;

    // Start is called before the first frame update
    void Start()
    {
        EndButton = GetComponent<Button>();
        EndButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
   
}
