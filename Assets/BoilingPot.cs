using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilingPot : MonoBehaviour, IInteractable
{
    public GameObject playerCamera;
    public GameObject player;

    [SerializeField]
    private GameObject minigamePanel;

    private GameObject ingredient;

    [SerializeField]
    private GameObject content;

    // private bool minigameStart;

    private int spawnedIngredients;

    GameObject changeIngredientSize;

    public List<Ingredient> product;

    public GameObject ingredientPrefab;

    public GameObject collectPot;

    public GameObject noIngredients;

    private float width;



    // Start is called before the first frame update
    void Start()
    {
        //minigameStart = false;
        spawnedIngredients = 0;
        width = minigamePanel.GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        if (changeIngredientSize != null)
        {
            changeIngredientSize.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }

    }

    public void Interact()
    {
        

        if (content.transform.childCount != 0)
        {
            ingredient = content.transform.GetChild(0).gameObject;
            playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
            player.gameObject.GetComponent<playerMovement>().MinigameStart();
            minigamePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            //minigameStart = true;
            Invoke("SpawnIngredient", 2f);
            Debug.Log("starting minigame");
        }
        else
        {
            noIngredients.SetActive(true);
            Invoke("TurnOffText", 2f);
        }
    }

    public void SpawnIngredient()
    {
        float tempPos = Random.Range(150, 1500);
        GameObject spawnedIngredient = Instantiate(ingredient, new Vector3(tempPos, 1300f, 1f), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        spawnedIngredient.GetComponent<Rigidbody2D>().gravityScale = 30;
        spawnedIngredient.tag = "Collect";
        changeIngredientSize = spawnedIngredient;
        spawnedIngredients++;



    }


    public void CollectedIngredients(int collected)
    {
        if (collected != 10)
        {
            Invoke("SpawnIngredient", 0.1f);
            
        }
        
        
        if (collected == 10)
        {
            Invoke("MinigameEnd", 1.5f);
        }
    }


    public void MinigameEnd()
    {

        Destroy(content.transform.GetChild(0).gameObject);

        collectPot.GetComponent<CatchIngredient>().MinigameEnd();
        ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[0];
        if (ingredient.GetComponent<IngredientDisplay>().ingredientMixingNumber == 13)
        {
            Instantiate(ingredientPrefab, new Vector3(transform.position.x + -1f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        }
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameEnd();
        player.gameObject.GetComponent<playerMovement>().MinigameEnd();
        minigamePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TurnOffText()
    {
        noIngredients.SetActive(false);
    }
}
