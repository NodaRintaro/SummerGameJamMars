using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("���E�ɓ�����")] private float _movePower = 1f;

    [SerializeField,Header("�W�����v��")] private float _jumpPower;

    [SerializeField, Header("�Q�[���I�[�o�[�ɂȂ鍂��")] private float _minPos = -3.5f;

    [SerializeField, Header("�X�^�~�i���炷��")] private int _damage = 1;
    
    [SerializeField,Header("Start���̗�")]�@private float _firstMovePower = 5;

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

            // �I�u�W�F�N�g�̈ړ�����
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
