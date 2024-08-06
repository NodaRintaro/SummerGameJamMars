﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("左右に動く力")] private float _movePower = 1f;

    [SerializeField,Header("ジャンプ力")] private float _jumpPower;

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
        // オブジェクトの移動処理

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            Debug.Log(transform.position.x);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            LoadScene.Instance.ChangeScene("atode");
            //ゴールしたときの判定
        }//Todo:名前決まり次第書きます

        if(collision.gameObject.tag == "GameOver")
        {
            LoadScene.Instance.ChangeScene("atode");
            //ゲームオーバーした時の判定
        }//Todo:名前決まり次第書きます
    }
}
