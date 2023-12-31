using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reinforcement : MonoBehaviour
{
    [SerializeField] GameObject unitObject;
    [SerializeField] GameObject effect;
    [SerializeField] float delay = 0.5f;
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] int condition;
    [SerializeField] float spawnCount;
    [SerializeField] UnityEvent endEvent;
    int spawnCounter = 0;
    List<GameObject> units = new();
    bool isOrder = false;

    private void Start()
    {
        isOrder = true;
        StartCoroutine(Order(Random.Range(min, max)));
    }

    public IEnumerator Order(int number)
    {
        yield return new WaitForSeconds(delay);
        for (int counter = 0;counter < number; counter++)
        {
            units.Add(Instantiate(unitObject, transform.position 
                + new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5)), Quaternion.identity));
            Instantiate(effect, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        isOrder = false;
        spawnCounter++;
    }

    private void FixedUpdate()
    {
        for(int counter = 0;counter <= units.Count - 1; counter++)
        {
            if(units[counter] == null)
            {
                units.RemoveAt(counter);

                if (units.Count == 0 && spawnCounter == spawnCount)
                {
                    endEvent.Invoke();
                    Destroy(gameObject);
                    return;
                }
            }
        }

        if(units.Count <= condition && !isOrder && spawnCount > spawnCounter)
        {
            StartCoroutine(Order(Random.Range(min, max)));
            isOrder = true;
        }
    }
}
