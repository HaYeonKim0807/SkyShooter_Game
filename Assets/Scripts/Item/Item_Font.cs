using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Font : Item, IEffect
{
    public override void ApplyItem()
    {
        DestroyThis();
    }

    public override void DestroyAfterTime()
    {
        Invoke("GetOpaque", 3.0f);
        Invoke("DestroyThis", 5.0f);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void GetOpaque()
    {
        Color32 color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 50);
    }

}
