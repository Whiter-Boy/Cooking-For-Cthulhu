using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisplay : MonoBehaviour
{

    public Ingredient ingredient;

    public Sprite ingredientSprite;

    private Mesh ingredientMesh;

    private Material ingredientMaterial;

    public int ingredientMixingNumber;

    public bool isCuttable;


    void Awake()
    {
        ingredientSprite = ingredient.mixingSprite;
        ingredientMixingNumber = ingredient.IngredientNumber;
        if(TryGetComponent<Renderer>(out Renderer renderer))
        {
            GetComponent<Renderer>().material = ingredient.ingredientMaterial;
        }
        if(TryGetComponent<MeshFilter>(out MeshFilter mesh))
        {
            GetComponent<MeshFilter>().mesh = ingredient.ingredientMesh;
        }
        
        if(TryGetComponent<MeshCollider>(out MeshCollider meshCollider))
        {
            GetComponent<MeshCollider>().sharedMesh = ingredient.ingredientMesh;
        }

        if(TryGetComponent<Transform>(out Transform transform))
        {
            transform.localScale = new Vector3(ingredient.ingredientScale.x, ingredient.ingredientScale.y, ingredient.ingredientScale.z);
        }
        


    }

    void Update()
    {
        if (transform.parent != null)
        {
            if (transform.parent.gameObject.CompareTag("Content"))
            {
                if (TryGetComponent<Transform>(out Transform transform))
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

            }
        }

        if (ingredient.isCuttable == true)
        {
            isCuttable = true;
        }

        
    }
   

}
