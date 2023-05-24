using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
    public new string name;

    public int IngredientNumber;

    public Material ingredientMaterial;

    public Sprite mixingSprite;

    public Mesh ingredientMesh;

    public Vector3 ingredientScale;


}
