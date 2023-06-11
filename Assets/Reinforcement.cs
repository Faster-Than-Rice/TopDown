using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforcement : MonoBehaviour
{
    [SerializeField] GameObject unit;
    public void Order(int number)
    {
        for(int counter = 0;counter < number; counter++)
        {
            Instantiate(unit, transform.position, Quaternion.identity);
        }
    }
}
