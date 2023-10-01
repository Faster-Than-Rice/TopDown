using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Money
{
    public static void SetValue(int value)
    {
        PlayerPrefs.SetInt("Money", value);
    }

    public static int GetValue()
    {
        return PlayerPrefs.GetInt("Money");
    }
}
