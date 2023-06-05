using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchIngredient : MonoBehaviour
{
    private int collectedIngredients;
    private int ingredientsSpawned;

    private TMPro

    [SerializeField]
    private GameObject boilPot;
    // Start is called before the first frame update
    void Start()
    {
        collectedIngredients = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log(collectedIngredients);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            Destroy(other.gameObject);
            collectedIngredients++;
            ingredientsSpawned++;
            boilPot.GetComponent<BoilingPot>().CollectedIngredients(collectedIngredients);
        }
    }

    public void MissIngredient()
    {
        ingredientsSpawned--;
        boilPot.GetComponent<BoilingPot>().CollectedIngredients(collectedIngredients);
    }

}
