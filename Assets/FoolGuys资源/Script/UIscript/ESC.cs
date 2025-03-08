using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ESC : MonoBehaviour
{
    public GameObject UIboard;
    private bool isShow = false;

    void Update()
    {
        if ( MyEventSystem.Instance.IsGameStart && MyEventSystem.Instance.CanESC)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(isShow)
                {
                    Hide();
                }
                else
                {
                    Show();
                    isShow = true;
                }
            }
            
        }
    }
    
    public void Show()
    {
        UIboard.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;

        MyEventSystem.Instance.TurnOnDOF();
    }
    public void Hide()
    {
        UIboard.SetActive(false);
        isShow = false;
        Time.timeScale = 1f;
        Cursor.visible = false;

        MyEventSystem.Instance.TurnOffDOF();
    }
}
