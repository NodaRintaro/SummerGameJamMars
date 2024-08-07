using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starge : MonoBehaviour
{
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = FindAnyObjectByType<PlayerMove>().GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if(_playerMove.IsMoving == true)
        {
             Destroy(gameObject);
        }
    }
}
