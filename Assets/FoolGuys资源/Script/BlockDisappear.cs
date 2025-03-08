using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDisappear : MonoBehaviour
{
    public Color origin;
    public Color warning;
    public Color final;
    public float triggerTime = 0.5f;
    public float warningTime = 0.5f;
    public float vanishTime = 0.3f;
    MeshRenderer meshRenderer;

    void Start()
    {
        // 获取物体上的 MeshRenderer 组件
        meshRenderer = GetComponent<MeshRenderer>();
    }
     public void State1()
    {
        meshRenderer.material.color = warning;
        Invoke("State2", warningTime);
    }
    public void State2()
    {
        meshRenderer.material.color = final;
        Invoke("Hide", vanishTime);
    }
    public void Hide()
    {
        GameObject.Find("Disappear").GetComponent<AudioSource>().Play();
        this.gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("State1", triggerTime);
    }
}
