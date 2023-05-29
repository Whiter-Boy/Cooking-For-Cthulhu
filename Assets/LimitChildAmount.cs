using System;
using UnityEngine;

public class LimitChildAmount : MonoBehaviour
{
    [SerializeField]
    private int maxChildAmount = 1;

    void Update()
    {
        if (transform.childCount > maxChildAmount)
        {
            for (int i = maxChildAmount; i < transform.childCount; i++)
            {

                Destroy(transform.GetChild(i).gameObject);

            }
        }
    }
}