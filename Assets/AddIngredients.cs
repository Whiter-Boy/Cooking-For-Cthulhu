using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddIngredients : MonoBehaviour
{

    private IngredientDisplay ingredientsScript;

    List<string> ingredients = new List<string>();

    public GameObject parentPanel;

    private Ingredient currentIngredient;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ingredient"))
        {
            // getting name and adding to ingredients list
            ingredientsScript = other.gameObject.GetComponent<IngredientDisplay>();

            ingredients.Add(ingredientsScript.ingredient.name);


            // Creating sprite for minigame
            GameObject newObj = new GameObject();

            newObj.name = ingredientsScript.ingredient.name;

            Ingredient otherIngredient = other.gameObject.GetComponent<IngredientDisplay>().ingredient;

            newObj.AddComponent<IngredientDisplay>().ingredient = otherIngredient;

            newObj.GetComponent<IngredientDisplay>().ingredientMixingNumber = ingredientsScript.ingredient.IngredientNumber;

            Image NewImage = newObj.AddComponent<Image>();

            NewImage.sprite = ingredientsScript.ingredient.mixingSprite;

            

            newObj.AddComponent<Rigidbody2D>();

            newObj.AddComponent<BoxCollider2D>();

            bool isCuttable = other.GetComponent<IngredientDisplay>().isCuttable;

            Debug.Log(isCuttable);

            newObj.GetComponent<Rigidbody2D>().gravityScale = 0;

            if (isCuttable == true)
            {
                newObj.AddComponent<cutIngredient>();

                newObj.AddComponent<draganddrop>();


            }


            newObj.GetComponent<RectTransform>().SetParent(parentPanel.transform);

            newObj.transform.localScale = new Vector3(1, 1, 1);
            newObj.transform.position = new Vector3(0, 0, 0);

            // other
            Destroy(other.gameObject);


            // checking if an ingredient gets added to the list
            //for(int i = 0; i < ingredients.Count; i++)
            //{
           //     Debug.Log(ingredients[i]);
           // }

        }

    }

}
