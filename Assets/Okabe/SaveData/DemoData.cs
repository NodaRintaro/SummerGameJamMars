using UnityEngine;

public class DemoData : MonoBehaviour
{
    [SerializeField] private SaveData _saveData;

    //Dataをセーブ
    public void Save(int clearTime)
    {
        _saveData.ClearTime = clearTime;
    }

    public void LoadData()
    {
        var clearTime = _saveData.ClearTime;
    }
}
