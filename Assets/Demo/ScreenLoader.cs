using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Update is called once per frame
    public void LoadObjectSelectionScene() 
    {
        SceneManager.LoadScene("UICompSelectScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
