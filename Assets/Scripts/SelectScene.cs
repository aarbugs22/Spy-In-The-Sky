using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour {

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        if (sceneName == "quit")
        {
            Application.Quit();
            Debug.Log("game quit");
        }
    }

    public void thisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
