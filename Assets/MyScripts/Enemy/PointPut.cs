using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility
{
    public static List<Vector3> Grid(Vector3 basePoint, float interval, int number)
    {
        Vector3 putPoint = new(basePoint.x - (number * interval / 2), basePoint.y, basePoint.z - (number * interval / 2));
        List<Vector3> putPoints = new();

        for(int horizontalCounter = 1;horizontalCounter <= number;horizontalCounter++)
        {
            for(int verticalCounter = 1;verticalCounter <= number;verticalCounter++)
            {
                putPoints.Add(new Vector3(putPoint.x, putPoint.y, putPoint.z));
                putPoint.z += interval;
            }
            putPoint.z = basePoint.z - (number * interval / 2);
            putPoint.x += interval;
        }
        return putPoints;
    }

    internal static T GetRandom<T>(params T[] Params)
    {
        return Params[Random.Range(0, Params.Length)];
    }

    internal static T GetRandom<T>(List<T> Params)
    {
        return Params[Random.Range(0, Params.Count)];
    }
}