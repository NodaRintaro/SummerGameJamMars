using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clear時間を計測
/// </summary>
public class ClearTime : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private SaveData _saveData;
    //Timeを描画する
    [SerializeField] private Text _timeText;
    //クリア時間を計測する
    private float _time;
    private bool _isClear = false;

    private void Start()
    {
        _time = 0f;
    }

    private void Update()
    {
        if (_playerMove.IsMoving &&_isClear == false)
        {
            _timeText.text = _time.ToString("F1");
            _time += Time.deltaTime;
        }
        if (_isClear)
        {
            //clearした時間を保存
            _saveData.ClearTime = _time;
        }
    }
}