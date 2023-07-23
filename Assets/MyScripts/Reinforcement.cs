using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinforcement : MonoBehaviour
{
    [SerializeField] GameObject unitObject;
    [SerializeField] GameObject effect;
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] int condition;
    List<GameObject> units = new();

    private void Start()
    {
        Order(Random.Range(min, max));
    }

    public void Order(int number)
    {
        for(int counter = 0;counter <= number; counter++)
        {
            units.Add(Instantiate(unitObject, transform.position, Quaternion.identity));
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        for(int counter = 0;counter <= units.Count - 1; counter++)
        {
            if(units[counter] == null)
            {
                units.RemoveAt(counter);
            }
        }

        if(units.Count <= condition)
        {
            Order(Random.Range(min, max));
        }
    }
}
