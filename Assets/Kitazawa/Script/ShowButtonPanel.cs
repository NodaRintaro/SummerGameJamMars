using UnityEngine;

/// <summary>
/// ��������\������
/// </summary>
public class ShowButtonPanel : MonoBehaviour
{
    [SerializeField, Header("�\������p�l��")] private GameObject _showPanel = default;
    [SerializeField, Header("��\���ɂ���p�l��")] private GameObject[] _unShowPanel = default;
    [SerializeField, Header("�\��/��\��")] private bool _isShow = true;

    private void Start()
    {
        _showPanel.SetActive(false);
    }

    private void Update()
    {
        if (!_showPanel.activeSelf) _showPanel.SetActive(_isShow); //�\��

        foreach (var item in _unShowPanel)//��\��
        {
            if (item.activeSelf) item.SetActive(!_isShow);
        }
    }

    public void OnClick(bool flag)
    {
        _isShow = flag;
    }
}