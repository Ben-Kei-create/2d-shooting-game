using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                transform.position += new Vector3(0f, 10f * Time.deltaTime, 0f);
                // // 弾のyポジションが5.0になった時にDestroyする
                // if (transform.position.y >= 5.0f)
                // {
                //     Destroy(gameObject);
                // }
    }
}
