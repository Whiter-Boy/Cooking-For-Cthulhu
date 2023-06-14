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

    void Awake()
    {
        knife = GameObject.Find("Knife");
    
        oldImage = GetComponent<Image>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        name = oldImage.sprite.name + "_Cut";



        newImage = Resources.Load<Sprite>(name);

    }   

    void Update()
    {
        dist = Vector3.Distance(knife.transform.position, transform.position);
        // Debug.Log(dist);
        if (dist < 30)
        {
            oldImage.sprite = newImage;
        }

    }

     

}
