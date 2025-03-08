using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float transitionSpeed = 30f; // 每秒变化的角度
    private float currentH = 0f;
    private float currentS = 0.48f;
    private float currentV = 0.72f;
    Renderer renderers;

    private void Start()
    {
        renderers = GetComponent<Renderer>();
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * 30 * Time.deltaTime); //自转
        currentH += transitionSpeed * Time.deltaTime;
        if (currentH >= 360f)
        {
            currentH -= 360f;
        }
        Color newColor = Color.HSVToRGB(currentH / 360f, currentS, currentV);
        renderers.material.color = newColor;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("Timer").GetComponent<StarCount>().AddStar();
        GameObject.Find("PickStar").GetComponent<AudioSource>().Play();
        gameObject.SetActive(false);
    }
}
