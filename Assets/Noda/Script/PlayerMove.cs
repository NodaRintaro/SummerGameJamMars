using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("左右に動く力")] private float _movePower = 1f;

    [SerializeField,Header("ジャンプ力")] private float _jumpPower;

    [SerializeField, Header("ゲームオーバーになる高さ")] private float _minPos = -3.5f;

    [SerializeField, Header("スタミナ減らす量")] private int _damage = 1;

    [SerializeField, Header("移動範囲の絶対値X")] private float _maxPosX;

    [SerializeField, Header("移動範囲の絶対値Y")] private float _maxPosY;

    [SerializeField, Header("移動範囲超えたら戻ってくる力")] private float _comeBack;

    private bool _isMoving = false;

    private Vector3 _dir;

    private Rigidbody2D _rb;

    private Vector2 _currentPos;

    private Vector2 _playerPos;

    public bool IsMoving => _isMoving;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {

        if (_isMoving)
        {
            float x = Input.GetAxis("Horizontal");

            _dir.x = x;

            transform.position += _dir * _movePower * Time.deltaTime;

            _playerPos = transform.position; 

            _playerPos.x = Mathf.Clamp(_playerPos.x, -_maxPosX, _maxPosX); 
            transform.position = new Vector2(_playerPos.x, _playerPos.y);

            // オブジェクトの移動処理
            if (Input.GetKeyDown(KeyCode.Space) && StaminaBar.instance.GetStamina() > 0 && this.transform.position.y < _maxPosY)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
                StaminaBar.instance.StaminaDown(_damage);
                Debug.Log(transform.position.x);
            }

            if (this.gameObject.transform.position.y < _minPos)
            {
                LoadScene.Instance.ChangeScene("result");
            }
        }
        if (!_isMoving)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                _isMoving = true;
                _rb.velocity = new Vector2(0, _jumpPower);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            _isMoving = false;
            LoadScene.Instance.ChangeScene("Goal");
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            StaminaBar.instance.StaminaDown(_damage);
        }
    }
}
