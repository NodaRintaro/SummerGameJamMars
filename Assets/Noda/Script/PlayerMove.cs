using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("���E�ɓ�����")] private float _movePower = 1f;

    [SerializeField,Header("�W�����v��")] private float _jumpPower;

    private Vector3 _dir;

    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");

        _dir.x = x;

        transform.position += _dir * _movePower * Time.deltaTime;
        // �I�u�W�F�N�g�̈ړ�����

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            Debug.Log(transform.position.x);
        }
    }
}
