using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary       //声明Boundary类，用于管理飞船活动的边界值
{
    public float xMin = -6.0f,
                 xMax = 6.0f,
                 zMin = -4.0f,
                 zMax = 14.0f;
}


public class PlayerController : MonoBehaviour {

    public Boundary boundary;       //添加Boundary类的实例

    public float speed = 5.0f;      //添加速度控制变量，并将初始值设为5.0f

    public float tilt = 10.0f;       //添加倾斜系数

    public float fireRate = 0.5f;   //发射间隔时间，默认0.5秒
    public GameObject shot;         //shot表示Bolt预制体
    public Transform shotSpawn;
    private float nextFire = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Fire1")&&Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");    //得到水平方向输入
        float moveVertical = Input.GetAxis("Vertical");         //得到垂直方向输入
        //用上面的水平方向(X轴)和垂直方向(Z轴)输入创建一个Vector3变量，作为刚体速度
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //GetComponent<Rigidbody>().velocity = movement * speed;

        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = movement * speed;
            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );
        }

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
