using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public RectTransform uiElement; // UI 元素的 RectTransform
    public float radius = 100f; // 圆弧半径
    public Vector2 center = Vector2.zero; // 圆心位置
    public float startAngle = 0f; // 起始角度
    public float speed = 1f; // 运动速度
    public float arcAngle = 30f; // 圆弧角度
    private float angle = 0f; // 当前角度
    private void Start()
    {
        uiElement = GetComponent<RectTransform>();
    }
    void Update()
    {
        float angle = startAngle + Mathf.Sin(Time.time * speed) * arcAngle / 2f;

        // 将角度转换为弧度
        float radians = angle * Mathf.Deg2Rad;

        // 计算 UI 元素的位置
        float x = center.x + Mathf.Cos(radians) * radius;
        float y = center.y + Mathf.Sin(radians) * radius;

        // 更新 UI 元素的位置
        uiElement.anchoredPosition = new Vector2(x, y);
    }
}