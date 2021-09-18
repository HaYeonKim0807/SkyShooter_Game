using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float health = 50.0f;
    public GameObject[] hp;
    int heart = 1;

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Destroy(coll.gameObject);
            GameObject _hp = GetComponent<Player>().hp[hp.Length - heart];
            Destroy(_hp);
            heart++;
        }
        
    }

    void Update()
    {
        
    }
}
