using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("左右に動く力")] private float _movePower = 1f;

    [SerializeField,Header("ジャンプ力")] private float _jumpPower;

    [SerializeField, Header("落ちたら死ぬ高さのオブジェクト")] private GameObject _seaLevel;

    [SerializeField, Header("スタミナ減らす量")] private int _damage = 1;

    [SerializeField, Header("移動範囲の絶対値X")] private float _maxPosX;

    [SerializeField, Header("移動範囲の絶対値Y")] private float _maxPosY;

    [SerializeField, Header("翼")] private GameObject[] _wings;

    private SpriteRenderer _spriteRenderer;

    private bool _isMoving = false;

    private bool _isInstantiate;

    private Vector3 _dir;

    private Rigidbody2D _rb;

    private Vector2 _playerPos;

    Animator _animator;

    public bool IsMoving => _isMoving;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
                SoundController.Instance.SePlay(SoundController.SeClass.SE.ButtonPush);
            }

            if(StaminaBar.instance.GetStamina() <= 0 && !_isInstantiate)
            {
                foreach (var wing in _wings)
                {
                    Instantiate(wing, this.gameObject.transform.position, Quaternion.identity);
                }
                _animator.SetBool("IsSutaminaZero",true);
                _isInstantiate = true;
            }

            if (this.gameObject.transform.position.y < _seaLevel.transform.position.y)
            {
                StartCoroutine("ChangeResultScene");
            }//ToDo:名前変える
        }
        if (!_isMoving)
        {
            if(Input.GetKeyDown(KeyCode.Space))
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
            _animator.SetBool("IsGoal", true);
        }//Todo:ゴール時の判定

        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine("ChangeColor");
        }
    }

    private IEnumerator ChangeColor()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        _spriteRenderer.color = new Color(255,255,255,255);
    }

    private IEnumerator ChangeResultScene()
    {
        yield return new WaitForSeconds(3f);
        LoadScene.Instance.ChangeScene("result");
    }
}
