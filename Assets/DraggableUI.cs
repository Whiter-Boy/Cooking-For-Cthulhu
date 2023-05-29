using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IDragHandler
{
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
        
        if(objPos.x > 277.5f && objPos.x < 838f)
        {
            transform.position = objPos;
        }

    }
}
