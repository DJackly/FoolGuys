using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFloor3 : MonoBehaviour
{
    public int towerNum = 6;
    private int currentTowerNum = 0;
    public int holeNum = 12;
    public GameObject towerPrefab;
    private int[] usedIndex;
    private int currentIndex = 0;

    private void Awake()
    {
        usedIndex = new int[holeNum];

        for (int i = 1; i <= holeNum; i++)//�ڶ�����
        {
            int e = Random.Range(0, transform.childCount);//���������e
            if (Array.Exists(usedIndex, element => element == e))//������й�������
            {
                i--;
                continue;
            }
            else usedIndex[currentIndex++] = e;   //δ�������������

            if (currentTowerNum < towerNum)
            {
                currentTowerNum++;
                Vector3 pos = transform.GetChild(e).position;   //����λ��
                pos.y += 2;
                Instantiate(towerPrefab, pos, Quaternion.Euler(-90f, 0f, 0f)); //���ɷ��Ɱ
            }

            Destroy(transform.GetChild(e).gameObject);  //������ô����ɾ�����������
        }

        GetComponent<SpawnStar>().Spawn(usedIndex);
    }
}
