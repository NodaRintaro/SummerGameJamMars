using System.Reflection;
using UnityEngine;

public class WingMove : MonoBehaviour
{
    [SerializeField,Header("�����Ă������ɓ�����")]private float _movePower = 1f;

    [SerializeField,Header("��]��")]private float _rotatePower = 1f;

    [SerializeField, Header("�H�������E��")] private Wings wings;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(wings == Wings.Right)
        {
            _rb.velocity = new Vector2(_movePower, -1);
            transform.Rotate(0, 0, -_rotatePower);
        }
        else
        {
            _rb.velocity = new Vector2(-_movePower, -1);
            transform.Rotate(0, 0, _rotatePower);
        }
    }

    private enum Wings 
    { 
        Left, 
        Right
    }
}
