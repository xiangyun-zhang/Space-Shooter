using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;        //小行星爆炸后的粒子对象
    public GameObject playerExplosion;  //飞船碰撞后爆炸式的粒子对象

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Boundary")
            return;

        Destroy(other.gameObject);      //销毁其他的物体
        Destroy(gameObject);            //销毁自身

        Instantiate(explosion, transform.position, transform.rotation);                         //实例化explosion的位置为小行星的位置
        if (other.tag == "Player")
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);   //playerExplos的位置为飞船位置
    }
}
