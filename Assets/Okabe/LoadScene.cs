using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>シーンを変えるためのクラス</summary>
public class LoadScene : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //シーンを変える
    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}