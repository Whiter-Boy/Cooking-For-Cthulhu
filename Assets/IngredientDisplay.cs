using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{

    public Ingredient ingredient;

    public Sprite ingredientSprite;

    private Material ingredientMaterial;

    public int ingredientMixingNumber;


    void Start()
    {
        ingredientSprite = ingredient.mixingSprite;
        ingredientMixingNumber = ingredient.IngredientNumber;
        if(TryGetComponent<Renderer>(out Renderer renderer))
        {
            GetComponent<Renderer>().material = ingredient.ingredientMaterial;
        }
            
    }
   

}
