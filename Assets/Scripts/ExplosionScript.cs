using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
