using UnityEngine;

/// <summary>Buttonにアタッチ</summary>
public class Button : MonoBehaviour
{
    //ボタンがクリックされた時対象のシーンに切り換える
    public void OnClickChangeScene(string sceneName)
    {
        LoadScene.Instance.ChangeScene(sceneName);
    }
}