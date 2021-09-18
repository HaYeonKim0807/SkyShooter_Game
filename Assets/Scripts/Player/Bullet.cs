using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //float speed = 0.1f;
    void Start()
    {
        Invoke("DestroySelf", 10.0f);   
    }


    void DestroySelf()
    {
        Destroy(gameObject);
    }

  
}
