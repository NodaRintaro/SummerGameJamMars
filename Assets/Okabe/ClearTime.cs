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
    public bool IsClear { get; set; } = false;

    private bool _isSave = false;

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
        if (_playerMove.IsMoving &&IsClear == false)
        {
            _timeText.text = _time.ToString("F1");
            _time += Time.deltaTime;
        }
        if (IsClear && _isSave == false)
        {
            SaveTimeJson();
        }
    }
    
    //ClearTimeをJSONに保存する
    private void SaveTimeJson()
    {
        _isSave = true;
        //Dataを指定
        var data = new TimerData();
        data._clearTime = _time;
        Debug.Log(data._clearTime);

        //Pathの指定
        var path = Path.Combine(Application.persistentDataPath, "TimeData.json");

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
        
        Debug.Log($"JSON Content: {newJson}"); // JSONデータが正しく作成されているか確認
    }
    
    // JSONファイルをリセットする
    [ContextMenu("ResetJSON")]
    public void ResetTimeJson()
    {
        // Pathの指定
        var path = Path.Combine(Application.persistentDataPath, "TimeData.json");

        // 空のリストで上書きする
        TimerDataList emptyDataList = new TimerDataList();
        var newJson = JsonUtility.ToJson(emptyDataList, true);
        File.WriteAllText(path, newJson);

        Debug.Log("JSONファイルがリセットされました。");

        // リセット後のファイル内容を確認
        if (File.Exists(path))
        {
            var fileContents = File.ReadAllText(path);
            Debug.Log("リセット後のファイル内容: " + fileContents);
        }
        else
        {
            Debug.LogError("リセットに失敗しました。ファイルが存在しません。");
        }
    }
}