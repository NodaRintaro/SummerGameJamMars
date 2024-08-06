using UnityEngine;

/// <summary>
/// Clear時間を計測
/// </summary>
public class ClearTime : MonoBehaviour
{
    [SerializeField] private SaveData _saveData;
    //クリア時間を計測する
    private float _time;
    private bool _isClear = false;

    private void Update()
    {
        //clearまでの時間を計測する
        if (_isClear == false)
            _time += Time.deltaTime;

        if (_isClear)
        {
            //clearした時間を保存
            _saveData.ClearTime = _time;
        }
    }
}