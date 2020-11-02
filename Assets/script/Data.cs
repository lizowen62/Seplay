using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static float counter = 1.3f;
    public static int Lang;
    public static int difficulty = 1;
    public static string userId;
    public static string JWT;
    public static string forme;
    public static int ok = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
