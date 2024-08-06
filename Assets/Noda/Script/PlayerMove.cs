using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("左右に動く力")] private float _movePower = 1f;

    [SerializeField,Header("ジャンプ力")] private float _jumpPower;

    [SerializeField, Header("ゲームオーバーになる高さ")] private float _minPos = -3.5f;

    [SerializeField, Header("スタミナ減らす量")] private int _damage = 1;
    
    [SerializeField,Header("Start時の力")]　private float _firstMovePower = 5;

    private bool _isMoving = false;

    private Vector3 _dir;

    private Rigidbody2D _rb;

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

            // オブジェクトの移動処理
            if (Input.GetKeyDown(KeyCode.Space) && StaminaBar.instance.GetStamina() > 0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
                StaminaBar.instance.StaminaDown(_damage);
                Debug.Log(transform.position.x);
            }

            if(this.gameObject.transform.position.y < _minPos)
            {
                LoadScene.Instance.ChangeScene("result");
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                _isMoving = true;
                _rb.velocity = new Vector2(_firstMovePower, _jumpPower);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            LoadScene.Instance.ChangeScene("Goal");
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            StaminaBar.instance.StaminaDown(_damage);
        }
    }
}
