using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour, IInteractable
{
    public GameObject playerCamera;
    public GameObject player;

    [SerializeField]
    private GameObject minigamePanel;

    private GameObject ingredient;

    [SerializeField]
    private GameObject content;

    public GameObject ingredientPrefab;

    public List<Ingredient> product;

    public GameObject noIngredients;

    public GameObject flame;

    private int ingredientNo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Interact()
    {
        ingredient = content.transform.GetChild(0).gameObject;
        if (ingredient != null)
        {
            ingredient = content.transform.GetChild(0).gameObject;
            ingredientNo = content.transform.GetChild(0).gameObject.GetComponent<IngredientDisplay>().ingredientMixingNumber;
            
            ingredient.transform.position = new Vector3(content.transform.position.x, content.transform.position.y, content.transform.position.z);
            playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
            player.gameObject.GetComponent<playerMovement>().MinigameStart();
            minigamePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            noIngredients.SetActive(true);
            Invoke("TurnOffText", 2f);
        }

        //minigameStart = true;

    }


    public void MinigameFinish()
    {
        Invoke("AutoCloseMinigame", 1.5f);


    }

    public void AutoCloseMinigame()
    {
        Destroy(content.transform.GetChild(0).gameObject);

        if (ingredientNo == 102)
        {
            ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[0];
            ingredientPrefab.tag = "Winning Dish";
        }

        else
        {
            
        }
        Instantiate(ingredientPrefab, new Vector3(transform.position.x + -1f, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameEnd();
        player.gameObject.GetComponent<playerMovement>().MinigameEnd();
        minigamePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

        flame.GetComponent<KeepMouseOnTarget>().MinigameFinish();
    }

    public void TurnOffText()
    {
        noIngredients.SetActive(false);
    }
}
