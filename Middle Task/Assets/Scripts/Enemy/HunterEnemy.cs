using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using Health;
using UnityEngine;

public class HunterEnemy : EnemyAttack
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _detectionRadius = 3f;

    private void Update()
    {
        FindCharacter();
    }

    private void FindCharacter()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<CharacterBehaviour>())
            {
                Debug.Log("Character is Find ");
                MoveToPlayer();
            }
        }
    }
    
    private void MoveToPlayer()
    {
        transform.position  = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
    }


}
