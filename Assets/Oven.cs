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

    public GameObject noIngredients;
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
        if (ingredient != null)
        {
            ingredient = content.transform.GetChild(0).gameObject;
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

    public void TurnOffText()
    {
        noIngredients.SetActive(false);
    }
}
