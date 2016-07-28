using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float lifetime = 2.0f;   //表示游戏对象的生命周期（这里只爆炸粒子对象）

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifetime);  //表示lifetime秒后销毁gameObject
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
