using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField,Header("�d��")]float _gravityPower = 1f;

    [SerializeField,Header("���E�ɓ�����")] float _movePower = 1f;
    //�i�ޗ�
    private Vector2 _dir = default;
    //
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //���E�̓���

        _dir = new Vector2(x, _gravityPower);

        _rb.velocity = _dir * _movePower;


    }
}
