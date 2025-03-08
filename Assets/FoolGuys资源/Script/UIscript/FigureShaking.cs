using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public RectTransform uiElement; // UI Ԫ�ص� RectTransform
    public float radius = 100f; // Բ���뾶
    public Vector2 center = Vector2.zero; // Բ��λ��
    public float startAngle = 0f; // ��ʼ�Ƕ�
    public float speed = 1f; // �˶��ٶ�
    public float arcAngle = 30f; // Բ���Ƕ�
    private float angle = 0f; // ��ǰ�Ƕ�
    private void Start()
    {
        uiElement = GetComponent<RectTransform>();
    }
    void Update()
    {
        float angle = startAngle + Mathf.Sin(Time.time * speed) * arcAngle / 2f;

        // ���Ƕ�ת��Ϊ����
        float radians = angle * Mathf.Deg2Rad;

        // ���� UI Ԫ�ص�λ��
        float x = center.x + Mathf.Cos(radians) * radius;
        float y = center.y + Mathf.Sin(radians) * radius;

        // ���� UI Ԫ�ص�λ��
        uiElement.anchoredPosition = new Vector2(x, y);
    }
}