using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI numText;
    public float countdownDuration = 3.8f; // ����ʱ����ʱ��
    public float timeRemaining = 3.8f; // ʣ��ʱ��
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
            // ����ʣ��ʱ��
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

            // ��ʣ��ʱ��ת��Ϊ��������ȷ������С��1
            int countdownValue = Mathf.Max((int)timeRemaining, 0);
            // ����TextMeshPro������ı�����
            if(countdownValue < 1)numText.text = "��ʼ";
            else numText.text = countdownValue.ToString();
        
            // �������ʱ������ִ����ز���
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
        GameObject.Find("OriginalPlatform").SetActive(false);   //�ڶ��س�ʼƽ̨��ʧ
        MyEventSystem.Instance.IsGameStart = true;
        MyEventSystem.Instance.CanESC = true;
        GameObject.Find("Player").GetComponent<ThirdPersonUserControl>().enabled = true;
        GameObject.Find("Timer").GetComponent<Timer>().isStart = true;//��Ϸ��ʼ��������ʱ
        
        gameObject.SetActive(false);
    }
}
