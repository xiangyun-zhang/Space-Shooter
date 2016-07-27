using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;      //添加速度控制变量，并将初始值设为5.0f

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");    //得到水平方向输入
        float moveVertical = Input.GetAxis("Vertical");         //得到垂直方向输入
        //用上面的水平方向(X轴)和垂直方向(Z轴)输入创建一个Vector3变量，作为刚体速度
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
    }
}
