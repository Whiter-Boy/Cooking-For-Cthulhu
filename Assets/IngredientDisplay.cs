using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{

    public Ingredient ingredient;

    public Sprite ingredientSprite;

    private Material ingredientMaterial;


    void Start()
    {
        ingredientSprite = ingredient.mixingSprite;
        GetComponent<Renderer>().material = ingredient.ingredientMaterial;
    }
   

}
