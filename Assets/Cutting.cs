using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{

    public float minCuttingVelocity = .001f;

    bool isCutting = false;

    Vector2 previousPosition;


    Rigidbody2D rb;
    BoxCollider2D BoxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }

    }

    void UpdateCut()
    {
        Vector2 newPosition = Input.mousePosition;
       // newPosition += new Vector2(236.8f, 231.5f);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime; 
        if (velocity > minCuttingVelocity)
        {
            BoxCollider.enabled = true;
        }
        else
        {
            BoxCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        previousPosition = Input.mousePosition;
        // previousPosition += new Vector2(236.8f, 231.5f);
        BoxCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        BoxCollider.enabled = false;
    }

}