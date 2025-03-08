using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToPlayAudio: MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;
    void Start()
    {
        // ��ȡ�����AudioSource���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    // ��UIԪ�ر����ʱ����
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.Play();
    }
}
