using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IntroContinue : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] sprites;
    public string[] texts;
    public string[] titles;
    public int maxIndex;
    public int currentIndex;
    public Image image;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI titleText;
    private void Start()
    {
        Refresh();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Continue();
    }
   
    public void EndAction()
    {
        GameObject.Find("Intro").GetComponent<IntroEnter>().Hide();
    }
    public void Refresh()
    {
        maxIndex = sprites.Length - 1;
        currentIndex = 0;
        if (maxIndex >= 0)
        {
            image.sprite = sprites[currentIndex];
            mainText.text = titles[currentIndex];
            titleText.text = texts[currentIndex];
        }
    }
    public void Continue()
    {
        currentIndex++;
        if(currentIndex <= maxIndex)
        {
            image.sprite = sprites[currentIndex];
            mainText.text = titles[currentIndex];
            titleText.text = texts[currentIndex];
        }
        else EndAction();
    }
}
