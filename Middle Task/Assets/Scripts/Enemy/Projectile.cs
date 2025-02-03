using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Enemy;
using Health;
using UnityEngine;

public class Projectile : EnemyAttack    
{
    
    [SerializeField] private float _speed = 5f;

    private Vector3 _direction;
    private Transform _target;
    
    private void Start()
    {
        StartCoroutine(DestroyProjectile());
        _target = GameObject.FindWithTag("Player").transform; 
        _direction = (_target.position - transform.position).normalized;

    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
   

