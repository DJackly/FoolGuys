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

        for (int i = 1; i <= holeNum; i++)//挖洞次数
        {
            int e = Random.Range(0, transform.childCount);//子物体序号e
            if (Array.Exists(usedIndex, element => element == e))//如果抽中过这个序号
            {
                i--;
                continue;
            }
            else usedIndex[currentIndex++] = e;   //未抽中则加入数组

            if (currentTowerNum < towerNum)
            {
                currentTowerNum++;
                Vector3 pos = transform.GetChild(e).position;   //塔的位置
                pos.y += 2;
                Instantiate(towerPrefab, pos, Quaternion.Euler(-90f, 0f, 0f)); //生成方尖碑
            }

            Destroy(transform.GetChild(e).gameObject);  //无论怎么样，删除这个子物体
        }

        GetComponent<SpawnStar>().Spawn(usedIndex);
    }
}
