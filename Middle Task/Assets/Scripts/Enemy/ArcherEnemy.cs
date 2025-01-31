using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
   [SerializeField] private float _detectionRadius = 8f;
   [SerializeField] private GameObject _projectilePrefab;
   [SerializeField] private Transform _target;
   [SerializeField] private float _waitTime = 2f;
   [SerializeField] private float _waitTimer;
   
   
   private bool _isAttack;
   private bool _isWaiting = false;

   private void Start()
   {
      _isAttack = false;
   }

   private void Update()
   {
      FindCharacter();
      StartShooting();
   }


   private void FindCharacter()
   {
      Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius);

      for (int i = 0; i < colliders.Length; i++)
      {
         if (colliders[i].GetComponent<CharacterBehaviour>())
         {
            Debug.Log("Find CHARACTER");

            _isAttack = true;
         }
      }
   }

   private void StartShooting()
   {
      if (_isAttack)
      {
         _waitTimer += Time.deltaTime;
         
         if (_waitTimer >= _waitTime)
         {
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            Vector3 direction = (_target.position - transform.position).normalized;
            projectile.GetComponent<Projectile>().SetDirection(direction);
            _waitTimer = 0;
         }
      }
   }
}
