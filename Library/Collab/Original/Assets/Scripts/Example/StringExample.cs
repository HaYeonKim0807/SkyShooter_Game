﻿using UnityEngine;

public class StringExample : MonoBehaviour
{
    delegate int myDelegate(int a, int b);

    void Start()
    {
        myDelegate del = delegate (int a, int b)
        {
            return a + b;
        };

        Debug.Log(del(1, 3));


    }
}