using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatchIngredient : MonoBehaviour
{
    private int collectedIngredients;
    private int ingredientsSpawned;

    [SerializeField]
    private TextMeshProUGUI count;

    [SerializeField]
    private GameObject boilPot;
    // Start is called before the first frame update
    void Start()
    {
        collectedIngredients = 0;
        count.SetText("0/10");
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
            count.SetText(collectedIngredients + "/10");
        }
    }

    public void MissIngredient()
    {
        ingredientsSpawned--;
        boilPot.GetComponent<BoilingPot>().CollectedIngredients(collectedIngredients);
    }

}
