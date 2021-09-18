using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Item, IEffect
{
    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3.0f);
        Invoke("DestroyThis", 5.0f);
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public override void ApplyItem()
    {
        GameObject game = GameObject.Find("Player");
        PlayerController controller = game.GetComponent<PlayerController>();

        controller.speed *= 1.3f;
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
