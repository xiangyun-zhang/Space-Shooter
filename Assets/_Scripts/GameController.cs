using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour {

    public Text scoreText;         //用于更新计分Text组件
    private int score;                      //用于保存当前分值
    public void AddScore(int newScoreValue)     //更新分值
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()      //更新Text组件
    {
        scoreText.text = "得分：" + score;
    }

    public int hazardCount;     //用来表示障碍物（小行星）的数量
    public float startWarit = 1.0f; //小行星对象生成前的等待时间；
    public float spawnWait;     //表示每次生成小行星对象后延迟的时间，单位为秒
    public float waveWait = 2.0f;   //两批小行星生成的时间间隔

    public GameObject hazard;              //该对象为实例化的障碍物对象，即Asteroid预制体
    public Vector3 spawnValues;            //spawnPosition表示实例化hazard对象的位置，spawnValues的x值表示Asteroid对象在场景中x轴方向上的极大值
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation;
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWarit);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);      //这一行表示在X轴的极大值和极小值间随机生成一个x值
                spawnPosition.z = spawnValues.z;
                spawnRotation = Quaternion.identity;                //表示无旋转
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
