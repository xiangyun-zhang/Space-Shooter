using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public float tumble = 10.0f;    //小行星旋转系数
    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().angularVelocity /*angularVelocity为物体角速度*/ = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
