using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _speed = 5f;
    private Vector3 _direction;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").transform; 
        _direction = (_target.position - transform.position).normalized;

    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
   

