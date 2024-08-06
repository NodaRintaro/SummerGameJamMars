using UnityEngine;

/// <summary>
/// 背景をスクロールする
/// </summary>
public class BackgroundScroll : MonoBehaviour
{
    [SerializeField, Header("速度")] private float _speed = 5f;
    [SerializeField, Header("背景")] private GameObject _gameObject = default;
    [SerializeField, Header("停止するかどうか")] private bool _isStop = default;

    public float Speed => _speed;

    private void Update()
    {
        //スクロール
        _gameObject.transform.Translate(Vector3.left * (Speed * Time.deltaTime));
    }
}