using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class KeepMouseOnTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private float counter;

    private bool mouse_over = false;

    private bool minigameFinished;

    public GameObject oven;

    [SerializeField]
    private TextMeshProUGUI cookedPercentage;
    // Start is called before the first frame update
    void Start()
    {
        minigameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 7 && minigameFinished == false)
        {
            Debug.Log("Minigame FInished");
            minigameFinished = true;
            oven.GetComponent<Oven>().MinigameFinish();
        }

        if (mouse_over && minigameFinished == false)
        {
            Counter();
        }

        if (counter !< 7)
        {
            cookedPercentage.SetText("Cooked: " + ((Math.Round((counter / 7), 1)) * 100) + "/100%");
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
    }

    public void Counter()
    {
        counter += Time.deltaTime;

        Math.Round(counter, 0);
    }

    public void MinigameFinish()
    {
        counter = 0;
        minigameFinished = false;
    }

}
