using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0f;
        GameObject.Find("Canvas/PublicUI/DeadInfor/BackGround").gameObject.SetActive(true);
        MyEventSystem.Instance.CanESC = false;
        Cursor.visible = true;

        MyEventSystem.Instance.TurnOnDOF();
    }
}
