using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin5 : Item, IEffect
{
    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3.0f);
        Invoke("DestroyThis", 5.0f);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public override void ApplyItem()
    {
        GameObject game = GameObject.Find("GameManager");
        GameManager manager = game.GetComponent<GameManager>();

        manager.On5Coin();
        DestroyThis();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            ApplyItem();
        }
    }

    public void GetOpaque()
    {
        Color32 color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 50);
    }
}
