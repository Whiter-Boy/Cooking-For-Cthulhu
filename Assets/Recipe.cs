using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour, IInteractable
{

    public GameObject player;
    public GameObject playerCamera;

    public GameObject recipePanel;
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
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
        player.gameObject.GetComponent<playerMovement>().MinigameStart();
        recipePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Looking At Recipe");
    }

    public void CloseRecipe()
    {
        player.gameObject.GetComponent<playerMovement>().MinigameEnd();
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameEnd();
        recipePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
