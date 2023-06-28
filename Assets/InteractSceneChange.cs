using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractSceneChange : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneSwitch", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SceneSwitch()
    {
        SceneManager.LoadScene(sceneName);
    }
}
