using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

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
    }
}
