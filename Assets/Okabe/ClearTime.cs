using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Clear時間を計測</summary>
public class ClearTime : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private SaveData _saveData;
    //Timeを描画する
    [SerializeField] private Text _timeText;
    //クリア時間を計測する
    private float _time;
    [SerializeField] private bool _isClear = false;

    //TimeのDataを保存するクラス
    [Serializable]
    public class TimerData
    {
        public float _clearTime;
    }
    
    //ClearTimeをリストにいれるクラス
    [Serializable]
    public class TimerDataList
    {
        //TimerのDataをリスト化
        public List<TimerData> _timerDataList = new();
    }

    private void Start()
    {
        //初期化
        _time = 0f;
    }

    private void Update()
    {
        //スタート中は時間を計測する
        if (_playerMove.IsMoving &&_isClear == false)
        {
            _timeText.text = _time.ToString("F1");
            _time += Time.deltaTime;
        }
        if (_isClear)
        {
            SaveTimeJson();
        }
    }

    //ClearTimeをJSONに保存する
    private void SaveTimeJson()
    {
        //Dataを指定
        var data = new TimerData();
        data._clearTime = _time;

        //Pathの指定
        var path = Path.Combine(Application.persistentDataPath, "clearTimeData.json");

        TimerDataList dataList;
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            dataList = JsonUtility.FromJson<TimerDataList>(json);
        }
        else
        {
            dataList = new TimerDataList();
        }
        
        dataList._timerDataList.Add(data);
        var newJson = JsonUtility.ToJson(dataList);
        File.WriteAllText(path,newJson);
        
        Debug.Log($"JSON Content: {newJson}");
    }
}