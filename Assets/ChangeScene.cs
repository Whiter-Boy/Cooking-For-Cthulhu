using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string sceneName;

    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        fadeOut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangingScene(string name)
    {
        fadeOut.SetActive(true);
        sceneName = name;

        Invoke("SceneSwitch", 2f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void SceneSwitch()
    {
        SceneManager.LoadScene(sceneName);
    }


}