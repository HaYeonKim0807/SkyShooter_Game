using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
        public abstract void ApplyItem();
        public abstract void DestroyAfterTime();

    void Start()
    {
            DestroyAfterTime();
    }
}

public interface IEffect
{
    void GetOpaque();
}

public enum Items
{
    Coin, SpeedUp, PowerUp
}