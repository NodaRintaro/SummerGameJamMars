using UnityEngine;

/// <summary>
/// 説明文を表示する
/// </summary>
public class ShowButtonPanel : MonoBehaviour
{
    [SerializeField, Header("表示するパネル")] private GameObject _showPanel = default;
    [SerializeField, Header("非表示にするパネル")] private GameObject[] _unShowPanel = default;
    [SerializeField, Header("表示/非表示")] private bool _isShow = true;

    private void Start()
    {
        _showPanel.SetActive(false);
    }

    private void Update()
    {
        if (!_showPanel.activeSelf) _showPanel.SetActive(_isShow); //表示

        foreach (var item in _unShowPanel)//非表示
        {
            if (item.activeSelf) item.SetActive(!_isShow);
        }
    }

    public void OnClick(bool flag)
    {
        _isShow = flag;
    }
}