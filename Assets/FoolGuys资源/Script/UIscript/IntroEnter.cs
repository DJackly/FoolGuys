using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class IntroEnter : MonoBehaviour
{
    public GameObject UIboard;
    public GameObject countDown;
    public float initialSpeed = 100f; // ��ʼ�ٶ�
    public float deceleration = 100f; // ���ٶ�
    private bool upMoving = false; // �Ƿ������ƶ�
    private bool downMoving = false;
    private float currentSpeed; // ��ǰ�ٶ�
    private float targetY; // Ŀ��Y����

    void Update()
    {
        if (upMoving)
        {
            // ���㵱ǰ֡Ӧ���ƶ��ľ���
            float distanceToMove = currentSpeed * Time.deltaTime;
            // ����λ��
            transform.position += new Vector3(0f, distanceToMove, 0f);
            // ��С�ٶ�
            currentSpeed -= deceleration * Time.deltaTime;
            // ����ٶ�С�ڵ��ڣ���ֹͣ�ƶ�
            if (currentSpeed <= 30) upMoving = false;
        }
        if (downMoving)
        {
            // ���㵱ǰ֡Ӧ���ƶ��ľ���
            float distanceToMove = currentSpeed * Time.deltaTime;
            // ����λ��
            transform.position -= new Vector3(0f, distanceToMove, 0f);
            // ��С�ٶ�
            currentSpeed -= deceleration * Time.deltaTime;
            // ����ٶ�С�ڵ��ڣ���ֹͣ�ƶ�
            if (currentSpeed <= 50)downMoving = false;
        }
    }
    public void StartUpMoving()
    {
        // ����Ŀ��Y����Ϊ��ǰλ�������ƶ�һС�ξ���
        targetY = transform.position.y + 50f;
        // �����ʼ�ٶȣ�ʹ�����ƶ��������ٶȵݼ���0
        currentSpeed = initialSpeed;
        float timeToStop = initialSpeed / deceleration;
        float averageSpeed = (initialSpeed + 0) / 2f;
        float distanceToTravel = targetY - transform.position.y;
        float timeToTravel = distanceToTravel / averageSpeed;
        float accelerationTime = timeToTravel - timeToStop;
        float initialAcceleration = (0 - initialSpeed) / accelerationTime;
        currentSpeed += initialAcceleration * Time.deltaTime;
        upMoving = true;
    }
    public void StartDownMoving()
    {
        // ����Ŀ��Y����Ϊ��ǰλ�������ƶ�һС�ξ���
        targetY = transform.position.y - 50f;
        // �����ʼ�ٶȣ�ʹ�����ƶ��������ٶȵݼ���0
        currentSpeed = initialSpeed;
        float timeToStop = initialSpeed / deceleration;
        float averageSpeed = (initialSpeed + 0) / 2f;
        float distanceToTravel =  transform.position.y - targetY;
        float timeToTravel = distanceToTravel / averageSpeed;
        float accelerationTime = timeToTravel - timeToStop;
        float initialAcceleration = (0 - initialSpeed) / accelerationTime;
        currentSpeed += initialAcceleration * Time.deltaTime;
        downMoving = true;
    }
    private void Start()
    {
        Show();
        MyEventSystem.Instance.TurnOnDOF();
    }
    public void Show()
    {
        UIboard.SetActive(true);
        Cursor.visible = true;
        StartUpMoving();
        GameObject.Find("Player").GetComponent<ThirdPersonUserControl>().enabled = false;
        MyEventSystem.Instance.TurnOnDOF();
    }
    public void Hide()
    {
        StartDownMoving();
        Cursor.visible = false;
        Invoke("HideUI", 0.5f);
    }
    public void HideUI()
    {
        countDown.SetActive(true);
        MyEventSystem.Instance.TurnOffDOF();
        UIboard.SetActive(false);
    }
}
