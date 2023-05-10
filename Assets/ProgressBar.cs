using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private int maximum = 100;
    public Image mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetCurrentFill(float current)
    {
        float fillAmount = (float)current / (float)maximum;

        
        if (fillAmount <= 1f)
        {
            mask.fillAmount = fillAmount;
            Debug.Log(fillAmount);
        }
    }
}
