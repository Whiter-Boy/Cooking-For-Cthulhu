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

    [SerializeField]
    private GameObject getIngredients;

    List<string> ingredients = new List<string>();

    private float fillAmount;

    private bool recievedIngredient;
    // Start is called before the first frame update
    void Start()
    {
        minigamePanel.SetActive(false);
        minigameStarted = false;
        recievedIngredient = false;
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

        Transform[] mixingContent = getIngredients.GetComponentsInChildren<Transform>();
        
        foreach (Transform t in mixingContent)
        {
            if (t!= null && t.gameObject != null)
            {
                ingredients.Add(t.gameObject.name);
            }
        }

        //for(int i = 0; i < ingredients.Count; i++)
        //{
        //    Debug.Log(ingredients[i]);
        //}

        if (ingredients.Contains("Flour") && ingredients.Contains("Water") && ingredients.Contains("Butter"))
        {
            Debug.Log("Give player batter");
        }




    }

}
