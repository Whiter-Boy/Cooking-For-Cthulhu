using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draganddrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    Vector3 offset;

    CanvasGroup canvasGroup;

    public string destinationTag = "DropArea"; // for future scripts

    private GameObject boundry;

    void Awake()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();

        }
        canvasGroup = gameObject.GetComponent<CanvasGroup>();

       

    }

    void Start()
    {
        boundry = GameObject.FindGameObjectWithTag("DropArea"); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("H");
        offset = transform.position - Input.mousePosition;
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RaycastResult raycastResult = eventData.pointerCurrentRaycast;
        if (raycastResult.gameObject?.tag == destinationTag)
        {
            transform.position = raycastResult.gameObject.transform.position;
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        Vector3 pos = new Vector3(boundry.transform.position.x + 750f, boundry.transform.position.y + -50f, boundry.transform.position.z);

        // confine x and y position to edge of cuttong board. Prevents ingredients from being dragged out of ui
        

        transform.position = pos;
    }
}
