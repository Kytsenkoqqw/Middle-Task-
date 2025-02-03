using System;
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private HealthSystem _healthSystem;

    private void Start()
    {
        _healthSystem.OnDeath += CharacterDie;
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float verticalMove = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        
        Vector3 moveDirection = new Vector3(horizontalMove, 0, verticalMove);
        transform.Translate(moveDirection, Space.World);
    }

    private void OnDestroy()
    {
        _healthSystem.OnDeath -= CharacterDie;
    }

    private void CharacterDie()
    {
        Debug.Log("character is death");
        Destroy(gameObject);
    }
}
