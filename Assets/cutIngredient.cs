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
    

    void Awake()
    {
        knife = GameObject.Find("Knife");
    
        oldImage = GetComponent<Image>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        name = oldImage.sprite.name + "_Cut";



        newImage = Resources.Load<Sprite>(name);

        knife = GameObject.FindWithTag("Knife");
        cuttingStation = GameObject.FindWithTag("Cutting Station");

    }   

    void Update()
    {
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



        if (cuts == 5)
        {
            oldImage.sprite = newImage;
            cuttingStation.GetComponent<CuttingStation>().MinigameFinish();
        }


    }

     

}
