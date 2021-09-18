using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prac : MonoBehaviour
{
    void Start()
    {
        Point_struct point1 = new Point_struct(1, 1);
        Point_struct point2 = point1;

        point2.x = 2;
        point2.y = 2;

        Debug.Log(point1.GetPoint());
        Debug.Log(point.GetPoint());
    }
}

struct Point_struct
{
    public int x;
    public int y;

    public Point_struct(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public string GetPoint()
    {
        return $"({x}, {y})";
    }
}
