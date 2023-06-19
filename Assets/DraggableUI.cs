using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IDragHandler
{

    public GameObject boundry1;
    public GameObject boundry2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 objPos = new Vector3(Input.mousePosition.x, transform.position.y, transform.position.z);

        if (this.gameObject.transform.position.x > boundry1.transform.position.x && this.gameObject.transform.position.x < boundry2.transform.position.x)
        {
            transform.position = objPos;
        }

        

    }
}
