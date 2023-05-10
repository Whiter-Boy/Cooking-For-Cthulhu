using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingBowl : MonoBehaviour, IInteractable
{
    public GameObject playerCamera;
    public GameObject player;

    [SerializeField]
    private GameObject minigamePanel;
    [SerializeField]
    private GameObject progressBar;

    bool minigameStarted;

    IngredientDisplay[] ingredients;

    private float fillAmount;
    // Start is called before the first frame update
    void Start()
    {
        minigamePanel.SetActive(false);
        minigameStarted = false;
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
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
        player.gameObject.GetComponent<playerMovement>().MinigameStart();
        minigamePanel.SetActive(true);
        minigameStarted = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("starting minigame");
    }

    public void MingameFinish()
    {
        ingredients = gameObject.GetComponentsInChildren<IngredientDisplay>();

        if (ingredients[0].ingredient.name == "flour")
        {
            Debug.Log("Flour");
        }
    }

}
