using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class StartGame : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene(sceneName);
    }
}



