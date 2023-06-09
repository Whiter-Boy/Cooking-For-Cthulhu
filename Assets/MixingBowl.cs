using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MixingBowl : MonoBehaviour, IInteractable
{
    public GameObject playerCamera;
    public GameObject player;

    [SerializeField]
    private GameObject minigamePanel;
    [SerializeField]
    private GameObject progressBar;

    bool minigameStarted;

    [SerializeField]
    private GameObject getIngredients;

    private float fillAmount;

    public List<Ingredient> product;

    public GameObject ingredientPrefab;

    public GameObject noIngredients;

    private int i;


    // Start is called before the first frame update
    void Start()
    {
        minigamePanel.SetActive(false);
        minigameStarted = false;
        i = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && minigameStarted)
        {
            fillAmount += 4;
            progressBar.gameObject.GetComponent<ProgressBar>().GetCurrentFill(fillAmount);
        }
        if (fillAmount == 100)
        {
            MingameFinish();
            
        }
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

    public void MingameFinish()
    {
        List<int> ingredients = new List<int>();

        IngredientDisplay[] mixingContent = getIngredients.GetComponentsInChildren<IngredientDisplay>();
        
        foreach (IngredientDisplay t in mixingContent)
        {
            if (t!= null && t.gameObject != null)
            {
                ingredients.Add(t.gameObject.GetComponent<IngredientDisplay>().ingredientMixingNumber);
            }

        }

        int ingredientTotal = ingredients.Sum();



        if (ingredientTotal == 10)
        {
            Debug.Log("Give player batter");
            ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[0];
            Instantiate(ingredientPrefab, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + -1f), Quaternion.identity);
        }

        if (ingredientTotal == 92)
        {
            Debug.Log("Give player seasoned Apple");
            ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[1];
            Instantiate(ingredientPrefab, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + -1f), Quaternion.identity);
        }

        if (ingredientTotal == 102)
        {
            Debug.Log("Give player uncooked Pie");
            ingredientPrefab.GetComponent<IngredientDisplay>().ingredient = product[2];
            Instantiate(ingredientPrefab, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + -1f), Quaternion.identity);
        }



        // Stop minigame from happening
        fillAmount = 0;
        minigameStarted = false;
        Invoke("AutoCloseMinigame", 2.0f);



    }

    public void AutoCloseMinigame()
    {
        int children = getIngredients.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            GameObject destroyChild;
            destroyChild = getIngredients.transform.GetChild(i).gameObject;
            Destroy(destroyChild);
        }

        //Instantiate(contentPrefab, new Vector3(transform.position.x, transform.position.y , transform.position.z, Quaternion.identity));
        progressBar.gameObject.GetComponent<ProgressBar>().GetCurrentFill(fillAmount);
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
