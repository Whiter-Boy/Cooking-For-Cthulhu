using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mixing : MonoBehaviour
{

    private IngredientDisplay ingredientsScript;

    List<string> ingredients = new List<string>();

    public GameObject parentPanel;


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

            Image NewImage = newObj.AddComponent<Image>();

            NewImage.sprite = ingredientsScript.ingredient.mixingSprite;

            newObj.GetComponent<RectTransform>().SetParent(parentPanel.transform);

            newObj.transform.localScale = new Vector3(2, 2, 2);
            newObj.transform.position = new Vector3(300, 350, 0);

            // other
            Destroy(other.gameObject);

            for(int i = 0; i < ingredients.Count; i++)
            {
                Debug.Log(ingredients[i]);
            }

        }
    }

}
