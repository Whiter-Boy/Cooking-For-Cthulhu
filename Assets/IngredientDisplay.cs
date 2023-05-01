using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{

    public Ingredient ingredient;

    private int combineValue;

    private Material ingredientMaterial;


    void Start()
    {
        combineValue = ingredient.combineValue;
        GetComponent<Renderer>().material = ingredient.ingredientMaterial;
        Debug.Log(ingredient.name);
    }

}
