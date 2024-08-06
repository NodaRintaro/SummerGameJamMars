using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>シーンを変えるためのクラス</summary>
public class LoadScene : MonoBehaviour
{
    //シングルトン化
    public static LoadScene Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    //シーンを変える
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}