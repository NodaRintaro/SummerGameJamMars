using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField,Header("重力")]float _gravityPower = 1f;

    [SerializeField,Header("左右に動く力")] float _movePower = 1f;
    //進む力
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
        //左右の入力

        _dir = new Vector2(x, _gravityPower);

        _rb.velocity = _dir * _movePower;


    }
}
