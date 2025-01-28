using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
   [SerializeField] private float _detectionRadius = 5f;
   [SerializeField] private GameObject _arrow;
   [SerializeField] private float _speedArrow;
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
         /*else
         {
            _isAttack = false;
         }*/
      }
   }

   private void StartShooting()
   {
      if (_isAttack)
      {
         if (_isWaiting)
         {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _waitTime)
            {
               _isAttack = false;
               _waitTimer = 0f;
            }
            return;
         }
      
         var arrow = Instantiate(_arrow, transform.position, Quaternion.identity);
         var direction = (arrow.transform.position - _target.position).normalized;
         arrow.transform.rotation = Quaternion.LookRotation(direction);
      
         arrow.transform.Translate(direction);
         _isWaiting = true;
      }
   }
}
