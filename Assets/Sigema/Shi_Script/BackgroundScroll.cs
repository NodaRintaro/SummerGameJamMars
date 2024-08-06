using UnityEngine;

/// <summary>
/// 背景をスクロールする
/// </summary>
public class BackgroundScroll : MonoBehaviour
{
    [SerializeField, Header("速度")] private float _speed = 5f;
    [SerializeField, Header("背景")] private GameObject _gameObject = default;
    [SerializeField] private PlayerMove _playerMove;

    public float Speed => _speed;

    // private void Start()
    // {
    //     _playerMove = FindObjectOfType<PlayerMove>();
    // }

    private void Update()
    {
        //スクロール
        if (_playerMove.IsMoving)
            _gameObject.transform.Translate(Vector3.left * (Speed * Time.deltaTime));
    }
}