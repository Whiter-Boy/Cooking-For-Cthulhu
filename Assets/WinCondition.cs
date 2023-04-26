using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private GameObject winDish;
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
        if (other.gameObject.CompareTag("Winning Dish"))
        {
            Debug.Log("Hooray!");
            winDish = other.gameObject;
            Invoke("DishEaten", 2f);

        }
    }

    private void DishEaten()
    {
        Destroy(winDish);
    }

    
}
