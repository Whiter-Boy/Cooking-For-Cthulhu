using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FadeInComplete", 1f);
        fadeIn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FadeInComplete()
    {
        fadeIn.SetActive(false);
    }
}
