using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class ObjInteract : MonoBehaviour
{
    [SerializeField] private LayerMask interactMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform interactTarget;
    [SerializeField] private float interactRange;

    private Rigidbody CurrentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, interactRange, interactMask))
            {
                CurrentObject = HitInfo.rigidbody;
            }

            if (CurrentObject)
            {
                CurrentObject.gameObject.TryGetComponent(out IInteractable interactObj);
                interactObj.Interact();

                Debug.Log("Interacting");
                return;
            }
            else
            {
                return;
            }


        }
    }

}
