using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    float health = 30.0f;

    public float Health
    {
        get { return health; }
    }

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            Die();
        }
    }
    void TakeDamage(float ratio)
    {
        health -= (int)(ratio*health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            Debug.Log("health : " + health);
            coll.gameObject.SetActive(false);
        }
    }

    void Die()
    {
        EventManager.RunEnemyDieEvent();
        Destroy(this.gameObject);
    }

    void Start()
    {
        Debug.Log("health : " + health);
    }

    public virtual void Move()
    {

    }
}
