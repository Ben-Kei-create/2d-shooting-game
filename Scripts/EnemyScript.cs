using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Declare phase as a class-level variable
    private float phase;
    public GameObject explosion;
    private GameControllerScript gameController;

    // Start is called before the first frame update
    // void Start()
    // {
    //     // ランダムなフェーズを生成し、敵の動きに変化を与える
    //     phase = Random.Range(0f, Mathf.PI * 2);
    //     gameController = GameObject
    //     .FindWithTag("GameController")
    //     .GetComponent<GameControllerScript>();
    // }

    //     void Start()
    // {
    //     phase = Random.Range(0f, Mathf.PI * 2);
    //     gameController = GameObject
    //         .FindWithTag("GameController")
    //         .GetComponent<GameControllerScript>();
    // }

    void Start()
{
    phase = Random.Range(0f, Mathf.PI * 2);

    GameObject gameControllerObject = GameObject.FindWithTag("GameController");

    if (gameControllerObject != null)
    {
        gameController = gameControllerObject.GetComponent<GameControllerScript>();
        if (gameController == null)
        {
            Debug.LogError("GameControllerScript が GameController にアタッチされていません。");
        }
    }
    else
    {
        Debug.LogError("GameController オブジェクトが見つかりません。'GameController' タグが設定されているか確認してください。");
    }
}


    // Update is called once per frame
    void Update()
    {
        // Mathfについて: 数学的な計算を行うためのユーティリティクラス
        // frameCountについて: 現在のフレーム数を取得するプロパティ
        // Mathf.Cosは、敵の横移動を滑らかにするために使用されます。
        // Time.frameCountに基づいて、時間とともに変化する横方向の位置を計算します。
        transform.position += new Vector3(Mathf.Cos(Time.frameCount * 0.01f + phase) * 0.009f, -2f * Time.deltaTime, 0f);
    }

    // Correctly defined OnTriggerEnter2D method
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameController.AddScore(10);
            Instantiate(explosion, transform.position, transform.rotation);
            // なぜ二つDestroy()があるのかというと、
            // 最初のDestroy(collision.gameObject)は、衝突したオブジェクトを削除するためです。
            // 次のDestroy(gameObject)は、この敵オブジェクト自身を削除するためです。
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.GameOver();
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

   }
}
