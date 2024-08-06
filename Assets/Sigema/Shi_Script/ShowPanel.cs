using UnityEngine;

/// <summary>
/// 説明文を表示する
/// </summary>
public class ShowPanel : MonoBehaviour
{
    [SerializeField, Header("パネル")] private GameObject _panel = default;
    private bool _isShow = default; // 表示するか

    private void Start()
    {
        _panel.SetActive(false);
    }

    private void Update()
    {
        _panel.SetActive(_isShow);
    }

    public void OnClick(bool flag)
    {
        _isShow = flag;
    }
}