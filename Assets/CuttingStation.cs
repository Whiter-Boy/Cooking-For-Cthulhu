using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CuttingStation : MonoBehaviour, IInteractable
{
    public GameObject playerCamera;
    public GameObject player;

    [SerializeField]
    private GameObject minigamePanel;

    bool minigameStarted;

    [SerializeField]
    private GameObject getIngredients;

    public List<Ingredient> product;

    public GameObject ingredientPrefab;

    public GameObject noIngredients;

    private int ingredientNo;

    void Start()
    {
        minigamePanel.SetActive(false);
        minigameStarted = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        ingredientPrefab.tag = "Ingredient";
        if (getIngredients.transform.childCount != 0)
        {
            playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
            player.gameObject.GetComponent<playerMovement>().MinigameStart();
            minigamePanel.SetActive(true);
            minigameStarted = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("starting minigame");
        }
        else
        {
            noIngredients.SetActive(true);
            Invoke("TurnOffText", 2f);
        }
    }

    public void MinigameFinish()
    {
        // List<int> ingredients = new List<int>();

        // IngredientDisplay[] mixingContent = getIngredients.GetComponentsInChildren<IngredientDisplay>();

        // foreach (IngredientDisplay t in mixingContent)
        // {
        //     if (t != null && t.gameObject != null)
        //     {
        //         ingredients.Add(t.gameObject.GetComponent<IngredientDisplay>().ingredientMixingNumber);
        //     }

        // }

        // int ingredientTotal = ingredients.Sum();



        // if (ingredientTotal == 10)
        // {
        //     Debug.Log("Give player batter");
        //     ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[0];
        //     Instantiate(ingredientPrefab, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + -1f), Quaternion.identity);
        // }
        getIngredients.transform.GetChild(0).gameObject.GetComponent<cutIngredient>().minigameFinished = true;
        ingredientNo = getIngredients.transform.GetChild(0).gameObject.GetComponent<IngredientDisplay>().ingredientMixingNumber;

        if (ingredientNo == 7)
        {
            ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[0];
            Instantiate(ingredientPrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + -0.8f), Quaternion.identity);
            Instantiate(ingredientPrefab, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + -0.75f), Quaternion.identity);
        }
        // Stop minigame from happening

        minigameStarted = false;
        Invoke("AutoCloseMinigame", 2.0f);



    }

    public void AutoCloseMinigame()
    {
        Destroy(getIngredients.transform.GetChild(0).gameObject);
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameEnd();
        player.gameObject.GetComponent<playerMovement>().MinigameEnd();
        minigamePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        getIngredients.transform.GetChild(0).gameObject.GetComponent<cutIngredient>().minigameFinished = false;
    }

    public void TurnOffText()
    {
        noIngredients.SetActive(false);
    }
}
