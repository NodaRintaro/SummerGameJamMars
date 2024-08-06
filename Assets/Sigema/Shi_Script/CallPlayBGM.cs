using UnityEngine;

public class CallPlayBGM : MonoBehaviour
{
    [SerializeField] private SoundController.BgmClass.BGM _bgmType = default;
    private void Start()
    {
        SoundController.Instance.BgmPlay(_bgmType);
    }
}