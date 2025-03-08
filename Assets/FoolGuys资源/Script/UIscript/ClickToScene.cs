using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickToScene : MonoBehaviour, IPointerClickHandler
{
    public int sceneNo;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (MyEventSystem.Instance != null)
        {
            MyEventSystem.Instance.TurnOffDOF();
        }
       
        SceneManager.LoadScene("ตฺ"+sceneNo+"นุ", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
