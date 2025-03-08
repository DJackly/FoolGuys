using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MyEventSystem : MonoBehaviour
{
    public static MyEventSystem Instance { get; private set; }
    public bool IsGameStart = false;
    public GameObject mainCamera;
    public bool CanESC = false; //能否呼出暂停界面
    public int requiredStar = 6;  //第二关专用
    public float requiredTime = 60f;    //第二关专用

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void TurnOnDOF() { 
       mainCamera.GetComponent<PostProcessVolume>().enabled = true;
    }
    public void TurnOffDOF()
    {
        mainCamera.GetComponent<PostProcessVolume>().enabled = false;
    }
}
