using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    public float mouseSense = 100f;
    public Transform playerBody;

    float xRot = 0f;

    private bool notInMinigame;

    // Start is called before the first frame update
    void Start()
    {
        notInMinigame = true;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (notInMinigame)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }

    }

    public void MinigameStart()
    {
        notInMinigame = false;
    }

    public void MinigameEnd()
    {
        notInMinigame = true;
    }
}
