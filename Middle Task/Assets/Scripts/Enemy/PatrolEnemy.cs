using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class PatrolEnemy: EnemyAttack
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private Transform[] _waypoints;

        private int _currentIndexWaypoint = 0;
        private float _waitTime = 2f;
        private float _waitTimer = 0f;
        private bool _isWaiting = false;

        private void Update()
        {
            Patrolling();
        }

        private void Patrolling()
        {
            if (_isWaiting)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _waitTime)
                {
                    _isWaiting = false;
                    _waitTimer = 0f;
                }
                return;
            }

            Transform targetWaypoint = _waypoints[_currentIndexWaypoint];
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                _currentIndexWaypoint++;
                if (_currentIndexWaypoint >= _waypoints.Length)
                {
                    _currentIndexWaypoint = 0;
                }
                _isWaiting = true;
            }
        }
    }
}