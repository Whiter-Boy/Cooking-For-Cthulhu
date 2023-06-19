using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class cutIngredient : MonoBehaviour

{

    public Image oldImage;
    public Sprite newImage;

    public string name;

    Rigidbody2D rb;

    public float dist;

    public GameObject knife;
    public Transform knifePos;
    public int cuts = 0;
    public bool alreadyCut = false;

    public GameObject cuttingStation;

    public bool minigameFinished;
    

    void Awake()
    {
        minigameFinished = false;
        knife = GameObject.Find("Knife");
    
        oldImage = GetComponent<Image>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        name = oldImage.sprite.name + "Cut";



        newImage = Resources.Load<Sprite>(name);

        

    }
    
    public void Start()
    {
        cuttingStation = GameObject.FindWithTag("Cutting Station");
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector3(60f, 60f, 0f);
    }

    public void Update()
    {
        knife = GameObject.FindWithTag("Knife");
        

        dist = Vector3.Distance(knife.transform.position, transform.position);
        // Debug.Log(dist);
        if (dist < 30 && alreadyCut == false)
        {
            cuts += 1;
            alreadyCut = true;

        }

        else
        {
            alreadyCut = false;
        }



        if (cuts == 5 && minigameFinished != true)
        {
            oldImage.sprite = newImage;
            cuttingStation.GetComponent<CuttingStation>().MinigameFinish();

        }


    }

     

}
