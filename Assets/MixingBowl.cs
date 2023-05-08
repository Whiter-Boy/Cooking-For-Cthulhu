using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingBowl : MonoBehaviour, IInteractable
{
    public GameObject Camera;
    public GameObject Player;

    [SerializeField]
    private GameObject minigamePanel;
    // Start is called before the first frame update
    void Start()
    {
        minigamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Interact()
    {
        Camera.gameObject.GetComponent<mouseLook>().MinigameStart();
        Player.gameObject.GetComponent<playerMovement>().MinigameStart();
        minigamePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("starting minigame");
    }

    public void MixingIngredients()
    {

    }
}
