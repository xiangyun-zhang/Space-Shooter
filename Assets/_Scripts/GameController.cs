﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;              //该对象为实例化的障碍物对象，即Asteroid预制体
    public Vector3 spawnValues;            //spawnPosition表示实例化hazard对象的位置，spawnValues的x值表示Asteroid对象在场景中x轴方向上的极大值
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation;
    void SpawnWaves()
    {
        spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);      //这一行表示在X轴的极大值和极小值间随机生成一个x值
        spawnPosition.z = spawnValues.z;
        spawnRotation = Quaternion.identity;                //表示无旋转
        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    // Use this for initialization
    void Start () {
        SpawnWaves();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}