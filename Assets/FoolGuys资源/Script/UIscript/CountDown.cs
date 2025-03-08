using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI numText;
    public float countdownDuration = 3.8f; // 倒计时持续时间
    public float timeRemaining = 3.8f; // 剩余时间
    AudioSource audioSource;
    public AudioClip bellRing;
    public AudioClip ticktock;
    public bool lowerThan3 = false;
    public bool lowerThan2 = false;
    public bool lowerThan1 = false;
    public bool isCounting = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ticktock;
        isCounting = true;
    }
    void Update()
    {
        if(isCounting)
        {
            // 更新剩余时间
            timeRemaining -= Time.deltaTime;
            if (lowerThan3 == false && timeRemaining < 3.7f)
            {
                lowerThan3 = true;
                audioSource.Play();
            }
            if(lowerThan2 == false && timeRemaining < 2.8f)
            {
                lowerThan2 = true;
                audioSource.Play();
            }
            if (lowerThan1 == false && timeRemaining < 1.8f)
            {
                lowerThan1 = true;
                audioSource.Play();
            
            }

            // 将剩余时间转换为整数，并确保它不小于1
            int countdownValue = Mathf.Max((int)timeRemaining, 0);
            // 更新TextMeshPro组件的文本内容
            if(countdownValue < 1)numText.text = "开始";
            else numText.text = countdownValue.ToString();
        
            // 如果倒计时结束，执行相关操作
            if (timeRemaining <= 0)
            {
                GameObject.Find("BellRing").GetComponent<AudioSource>().Play();
                isCounting = false;
                GameStart();
            }
        }
        
    }
    public void GameStart()
    {
        GameObject.Find("OriginalPlatform").SetActive(false);   //第二关初始平台消失
        MyEventSystem.Instance.IsGameStart = true;
        MyEventSystem.Instance.CanESC = true;
        GameObject.Find("Player").GetComponent<ThirdPersonUserControl>().enabled = true;
        GameObject.Find("Timer").GetComponent<Timer>().isStart = true;//游戏开始，开启计时
        
        gameObject.SetActive(false);
    }
}
