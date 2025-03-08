using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarCount : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    private int requiredStar;

    private void Start()
    {
        requiredStar = MyEventSystem.Instance.requiredStar;
        count = 0;
        countText.text = "���ǣ�" + count + "/" + requiredStar;
    }
    public void AddStar()
    {
        count++;
        countText.text = "���ǣ�" + count + "/" + requiredStar;
        if(count == requiredStar)
        {
            GameObject.Find("Timer").GetComponent<Timer>().TimesOut();
        }
    }
    
}
