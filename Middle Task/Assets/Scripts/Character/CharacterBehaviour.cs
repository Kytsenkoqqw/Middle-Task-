using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;

        transform.Translate(horizontalMove, 0 , verticalMove);
        transform.LookAt(transform);
    }
}
