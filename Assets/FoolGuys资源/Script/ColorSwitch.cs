using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwitch : MonoBehaviour
{
    public float transitionSpeed = 60f; // ÿ��仯�ĽǶ�
    private float currentH = 0f;
    private float currentS = 0.28f;
    private float currentV = 0.72f;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        // ����ʱ��仯Hֵ
        currentH += transitionSpeed * Time.deltaTime;
        if (currentH >= 360f)
        {
            currentH -= 360f;
        }
        // ������ɫ������Hֵ�仯
        Color newColor = Color.HSVToRGB(currentH / 360f, currentS, currentV);
        // Ӧ������ɫ���������Ⱦ����Renderer����
        image.color = newColor;
    }

}
