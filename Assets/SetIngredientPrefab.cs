using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIngredientPrefab : MonoBehaviour
{
    public GameObject ingredientPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ingredientPrefab.tag = "Winning Dish";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
