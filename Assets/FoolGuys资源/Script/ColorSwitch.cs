using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwitch : MonoBehaviour
{
    public float transitionSpeed = 60f; // 每秒变化的角度
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
        // 根据时间变化H值
        currentH += transitionSpeed * Time.deltaTime;
        if (currentH >= 360f)
        {
            currentH -= 360f;
        }
        // 创建颜色，利用H值变化
        Color newColor = Color.HSVToRGB(currentH / 360f, currentS, currentV);
        // 应用新颜色到物体的渲染器（Renderer）上
        image.color = newColor;
    }

}
