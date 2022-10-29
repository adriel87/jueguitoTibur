using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public int sceneNumber;

    // Start is called before the first frame update
    public void StartScene()
    {
        Debug.Log(sceneNumber);
        SceneManager.LoadScene(sceneNumber);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }
}
