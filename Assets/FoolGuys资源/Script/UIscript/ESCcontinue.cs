using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ESCcontinue : MonoBehaviour, IPointerClickHandler
{
    public GameObject esc;
    public void OnPointerClick(PointerEventData eventData)
    {
        esc.GetComponent<ESC>().Hide();
    }
}
