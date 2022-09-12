using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartGameScript : MonoBehaviour
{
public void ChangeScene(string SceneName)
    {
        Debug.Log("Switching scenes" + SceneName);
        SceneManager.LoadScene(SceneName);
    }
}
