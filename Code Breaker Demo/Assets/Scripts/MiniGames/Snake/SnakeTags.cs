using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTags : MonoBehaviour
{
    public static string Wall = "Wall";
    public static string Fruit = "Food";
    public static string Bomb = "Bomb";
    public static string Tail = "Tail"; 

}
public class Metrics
{
    public static float NODE = 0.25f; 

}
public enum PlayerDirection
{
    LEFT = 0,
    UP = 1,
    RIGHT = 2,
    DOWN = 3, 
    COUNT = 4

}
