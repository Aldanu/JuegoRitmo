using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public String scene;
    // Start is called before the first frame update
    public void startSceneGame()
    {
        SceneManager.LoadScene(scene);
    }
}
