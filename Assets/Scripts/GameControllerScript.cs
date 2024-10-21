using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject enemy; // Ensure this is assigned in the Inspector
private int score;
public Text scoreText;
public Text replayText;
private bool isGameOver;
    // IEnumeratorとは
    /// 敵を一定間隔で生成するコルーチンです。
    /// 敵が生成されるまでの待機時間を示すIEnumerator。
    IEnumerator SpawnEnemy(){
        while (true){
            Instantiate(
                enemy,
                new Vector3(Random.Range(-8f, 8f), transform.position.y, 0f),
                transform.rotation
            );
            // yieldとは: コルーチンの実行を一時停止し、指定した条件が満たされるまで待機するためのキーワードです。
            // WaitForSeconds()とは: 指定した秒数だけ待機するためのUnityのクラスで、コルーチン内で使用されます。
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine()は、指定したコルーチンを開始するためのメソッドです。
        // "SpawnEnemy"という名前のコルーチンを開始します。
        StartCoroutine("SpawnEnemy");
        score = 0;
        UpdateScoreText();
        replayText.text = "";
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            return;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void AddScore(int scoreToAdd){
        score += scoreToAdd;
        UpdateScoreText();
    }
void UpdateScoreText(){
    scoreText.text = "Score: " + score;
}


public void GameOver(){
    isGameOver = true;
    replayText.text = "Hit SAPACE to replay!";
}
}
