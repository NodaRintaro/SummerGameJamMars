using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonLoad : MonoBehaviour
{
    //UIで表示するText
    [SerializeField] private Text[] _rankingTexts;

    [Serializable]
    public class TimerData
    {
        public float _clearTime;
    }

    [Serializable]
    public class TimerDataList
    {
        public List<TimerData> _timerDataList = new();
    }

    private void Start()
    {
        LoadAndDisplayRanking();
    }

    private void LoadAndDisplayRanking()
    {
        var path = Path.Combine(Application.persistentDataPath, "TimeData.json");

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);

            var dataList = JsonUtility.FromJson<TimerDataList>(json);

            if (dataList._timerDataList.Count > 0)
            {
                dataList._timerDataList.Sort((x, y) => x._clearTime.CompareTo(y._clearTime));

                // 配列内の数値をデバッグログで表示
                Debug.Log("デバッグ: タイムデータの内容を確認");
                foreach (var timerData in dataList._timerDataList)
                {
                    Debug.Log($"Time: {timerData._clearTime:F1}秒");
                }

                for (var i = 0; i < _rankingTexts.Length; i++)
                {
                    if (i < dataList._timerDataList.Count)
                    {
                        _rankingTexts[i].text = $"{i + 1}. {dataList._timerDataList[i]._clearTime:F1}秒";
                        Debug.Log(_rankingTexts[i].text = $"{i + 1}. {dataList._timerDataList[i]._clearTime:F1}秒");
                    }
                    else
                    {
                        _rankingTexts[i].text = $"{i + 1}. ---";
                    }
                }
            }
            else
            {
                Debug.Log("データが空です。");
                for (var i = 0; i < _rankingTexts.Length; i++)
                {
                    _rankingTexts[i].text = $"{i + 1}. ---";
                }
            }
        }
        else
        {
            Debug.LogWarning("保存されたタイムデータが見つかりませんでした。");
        }
    }
}