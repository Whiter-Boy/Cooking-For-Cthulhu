using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class knifeHandling : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector3 offset;

    CanvasGroup canvasGroup;

    public string destinationTag = "DropArea"; // for future scripts

    public float minCuttingVelocity = .001f;

    bool isCutting = false;

    Vector2 previousPosition;


    Rigidbody2D rb;
    BoxCollider2D BoxCollider;

    void Awake()
    {
  
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();

        }
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        rb = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        canvasGroup.alpha = 0.7f;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = false;

        StartCutting();

        if (isCutting)
        {
            UpdateCut();
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = new Vector3(236.8f, 231.5f, 0);
        Debug.Log(transform.position);
        // transform.position = new Vector3(-307.2f, -28, 0);
        RaycastResult raycastResult = eventData.pointerCurrentRaycast;
        if (raycastResult.gameObject?.tag == destinationTag)
        {
            transform.position = raycastResult.gameObject.transform.position;
        }
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = true;

        Vector3 pos = transform.position;

        StopCutting();

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
