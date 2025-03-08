using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class SpawnStar : MonoBehaviour
{
    public int requiredStar = 1;
    public GameObject starPrefab;
    private int[] usedIndex;
    private int currentIndex = 0;
    public bool Floor2;

    private void Start()
    {
        if (Floor2)
        {
            usedIndex = new int[24];

            for (int i = 1; i <= requiredStar; i++)
            {
                int e = Random.Range(0, transform.childCount);//���������e
                if (Array.Exists(usedIndex, element => element == e))//������й�������
                {
                    i--;
                    continue;
                }
                else usedIndex[currentIndex++] = e;   //δ�������������

                Vector3 pos = transform.GetChild(e).position;
                pos.y += 2;
                Instantiate(starPrefab, pos, Quaternion.identity);//��������
            }

        }
    }
    public void Spawn(int[] usedList)
    {
        usedIndex = new int[24];
        Array.Copy(usedList, usedIndex, usedList.Length);//�����ù����������
        currentIndex = usedList.Length;

        for (int i = 1; i <= requiredStar; i++)
        {
            int e = Random.Range(0, transform.childCount);//���������e
            if (Array.Exists(usedIndex, element => element == e))//������й�������
            {
                i--;
                continue;
            }
            else usedIndex[currentIndex++] = e;   //δ�������������

            Vector3 pos = transform.GetChild(e).position;
            pos.y += 2;
            Instantiate(starPrefab, pos, Quaternion.identity);//��������
        }

    }

    private void Update()
    {
    }
}
