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
        public float _time;
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
        string path = Path.Combine(Application.persistentDataPath, "clearTimeData.json");

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);

            var dataList = JsonUtility.FromJson<TimerDataList>(json);

            for (var i = 0; i < _rankingTexts.Length; i++)
            {
                if (i < dataList._timerDataList.Count)
                {
                    _rankingTexts[i].text = $"{i + 1}. {dataList._timerDataList[i]._time:F1}秒";
                }
                else
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