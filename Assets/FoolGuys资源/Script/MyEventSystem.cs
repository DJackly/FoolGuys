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
    public bool CanESC = false; //�ܷ������ͣ����
    public int requiredStar = 6;  //�ڶ���ר��
    public float requiredTime = 60f;    //�ڶ���ר��

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
