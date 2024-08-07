using System.Reflection;
using UnityEngine;

public class WingMove : MonoBehaviour
{
    [SerializeField,Header("落ちてく方向に働く力")]private float _movePower = 1f;

    [SerializeField,Header("回転力")]private float _rotatePower = 1f;

    [SerializeField, Header("羽が左か右か")] private Wings wings;

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
