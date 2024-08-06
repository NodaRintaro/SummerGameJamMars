using UnityEngine;

/// <summary>
/// テスト用　音の呼び出し
/// </summary>
public class TestCallSound : MonoBehaviour
{
    private void Start()
    {
        SoundController.Instance.BgmPlay(SoundController.BgmClass.BGM.Test);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundController.Instance.SePlay(SoundController.SeClass.SE.Test);
        }
    }
}