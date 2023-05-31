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



    // Start is called before the first frame update
    void Start()
    {
        //minigameStart = false;
        spawnedIngredients = 0;
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
        ingredient = content.transform.GetChild(0).gameObject;
        playerCamera.gameObject.GetComponent<mouseLook>().MinigameStart();
        player.gameObject.GetComponent<playerMovement>().MinigameStart();
        minigamePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        //minigameStart = true;
        InvokeRepeating("SpawnIngredient", 2, 1.5f);
        Debug.Log("starting minigame");
    }

    public void SpawnIngredient()
    {
        float tempPos = Random.Range(302.5f, 798.5f);
        GameObject spawnedIngredient = Instantiate(ingredient, new Vector3(tempPos, 550f, 1f), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        spawnedIngredient.AddComponent<Rigidbody2D>().gravityScale = 30;
        spawnedIngredient.AddComponent<PolygonCollider2D>();
        spawnedIngredient.tag = "Collect";
        changeIngredientSize = spawnedIngredient;
        spawnedIngredients++;



    }


    public void CollectedIngredients(int collected)
    {
        if (collected == 10)
        {
            CancelInvoke();
        }
    }


    public void MinigameEnd()
    {

    }
}
