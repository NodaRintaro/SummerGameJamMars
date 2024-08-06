using UnityEngine;

//必要な情報を保存しておく場所
[CreateAssetMenu(menuName = "DataBase")]
public class SaveData : ScriptableObject
{
    //クリアした時間を保存
    public float ClearTime { get; set; }
}
