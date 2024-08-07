using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clear時のタイトル画面に表示
/// </summary>
public class LoadClearTime : MonoBehaviour
{
   [SerializeField,Header("Dataを保存するスクリプタブルオブジェクト")] 
   private SaveData _saveData;
   [SerializeField] private Text _clearText;
   private void Start()
   {
      //保存してあるデータを取り出して表示させる
      _clearText.text = _saveData.ClearTime.ToString();
   }
}
