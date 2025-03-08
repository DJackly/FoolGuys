using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToPlayAudio: MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;
    void Start()
    {
        // 获取或添加AudioSource组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    // 当UI元素被点击时调用
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
