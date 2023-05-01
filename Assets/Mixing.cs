using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixing : MonoBehaviour
{
    List<string> ingredients = new List<string>();
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
            ingredients.Add(other.gameObject.name);

            Destroy(other.gameObject);

            for(int i = 0; i < ingredients.Count; i++)
            {
                Debug.Log(ingredients[i]);
            }

        }
    }

}
