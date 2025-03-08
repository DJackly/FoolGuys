using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Timer : MonoBehaviour
{
    private float requiredTime;
    private float lessTime;
    public TextMeshProUGUI timeText;
    public bool isStart;
    public bool isEnd;
    private float currentTimeScale = 1f;
    private float duration = 2f;
    private float endTimeCount = 0;
    private void Start()
    {
        requiredTime = MyEventSystem.Instance.requiredTime;
        if(requiredTime == 0)
        {
            requiredTime = 120; //如未手动赋值则给个120
        }
        lessTime = requiredTime;
        isStart = false;
        isEnd = false;
        endTimeCount = 0;
        timeText.text = "倒计时:" + (int)lessTime;
    }
    private void Update()
    {
        if (isStart)
        {
            lessTime -= Time.deltaTime;
            timeText.text = "倒计时:" + (int)lessTime;
            if (lessTime<=0)
            {
                TimesOut();
                isStart = false;
                timeText.text = "倒计时:" + 0;
            }
        }
        if (isEnd)
        {
            endTimeCount += Time.deltaTime/Time.timeScale;
            currentTimeScale = Mathf.Lerp(1f, 0f, endTimeCount / duration);
            Time.timeScale = currentTimeScale;
            if (Time.timeScale < 0.1f)
            {
                Time.timeScale = 0f;
                isEnd = false;
            }
        }
        
    }
    public void TimesOut()
    {
        isStart = false;
        isEnd = true;

        GameObject.Find("Canvas/PublicUI/WinInfor/BackGround").gameObject.SetActive(true);
        MyEventSystem.Instance.CanESC = false;
        Cursor.visible = true;
        MyEventSystem.Instance.TurnOnDOF();
    }
}
