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

    private bool minigameStart;


    // Start is called before the first frame update
    void Start()
    {
        minigameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (minigameStart)
        {
            InvokeRepeating("SpawnIngredient", 2,2);
        }
    }

    public void Interact()
    {
        ingredient = content.transform.GetChild(0).gameObject;
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
        player.gameObject.GetComponent<playerMovement>().MinigameStart();
        minigamePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        minigameStart = true;
        Debug.Log("starting minigame");
    }

    public void SpawnIngredient()
    {
        float tempPos = Random.Range(-8f, 8f);
        Instantiate(ingredient, new Vector3(tempPos, 252f, 0f), Quaternion.identity);

    }
}
