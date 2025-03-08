using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class IntroEnter : MonoBehaviour
{
    public GameObject UIboard;
    public GameObject countDown;
    public float initialSpeed = 100f; // 初始速度
    public float deceleration = 100f; // 减速度
    private bool upMoving = false; // 是否正在移动
    private bool downMoving = false;
    private float currentSpeed; // 当前速度
    private float targetY; // 目标Y坐标

    void Update()
    {
        if (upMoving)
        {
            // 计算当前帧应该移动的距离
            float distanceToMove = currentSpeed * Time.deltaTime;
            // 更新位置
            transform.position += new Vector3(0f, distanceToMove, 0f);
            // 减小速度
            currentSpeed -= deceleration * Time.deltaTime;
            // 如果速度小于等于，则停止移动
            if (currentSpeed <= 30) upMoving = false;
        }
        if (downMoving)
        {
            // 计算当前帧应该移动的距离
            float distanceToMove = currentSpeed * Time.deltaTime;
            // 更新位置
            transform.position -= new Vector3(0f, distanceToMove, 0f);
            // 减小速度
            currentSpeed -= deceleration * Time.deltaTime;
            // 如果速度小于等于，则停止移动
            if (currentSpeed <= 50)downMoving = false;
        }
    }
    public void StartUpMoving()
    {
        // 设置目标Y坐标为当前位置向上移动一小段距离
        targetY = transform.position.y + 50f;
        // 计算初始速度，使得在移动过程中速度递减至0
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
        // 设置目标Y坐标为当前位置向上移动一小段距离
        targetY = transform.position.y - 50f;
        // 计算初始速度，使得在移动过程中速度递减至0
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
