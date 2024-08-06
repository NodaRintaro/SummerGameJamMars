using UnityEngine;

public class ButtonSample : MonoBehaviour
{
    public void OnClickDemo()
    {
        LoadScene.Instance.ChangeScene("Demo2");
    }
}