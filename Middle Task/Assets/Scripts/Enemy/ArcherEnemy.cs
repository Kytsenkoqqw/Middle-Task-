using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
   [SerializeField] private float _detectionRadius = 8f;
   [SerializeField] private GameObject _projectilePrefab;
   [SerializeField] private float _waitTime = 2f;
   [SerializeField] private float _waitTimer;
   [SerializeField] private Transform _shootPoint;
   
   private bool _isAttack;
   private bool _isWaiting = false;
   
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
            var projectile = Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
            _waitTimer = 0f;
         }
      }
   }
}
