using UnityEngine;

public class CallGameOverSE : MonoBehaviour
{
    private void Start()
    {
        SoundController.Instance.SePlay(SoundController.SeClass.SE.GameOverSe);
    }
}