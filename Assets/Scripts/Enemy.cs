using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform playerTarget;
    
     [Header("FieldProperty")]
    [SerializeField] private int _hp = 100;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Dead _dead;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _dead = GetComponent<Dead>();
    }
    public void SetDamage()
    {
     
        _hp -= 50;
        if (_hp <= 0)
        {
            Dead();
        }
    }
    public void Move()
    {

        _navMeshAgent.SetDestination(playerTarget.position);

    }

    public void StartMove()
    {
        if (_navMeshAgent)
        {
        _navMeshAgent.enabled = true;
        _animator.SetBool("Run", true);
        }
    }

    public void Stop()
    {
        _navMeshAgent.enabled = false;

        _animator.SetBool("Run", false);
    }

    public  void Attack()
    {
       // throw new System.NotImplementedException();
    }

    public void Dead()
    {
        _dead.DeadMyself();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is BoxCollider && other.TryGetComponent<Player>(out  Player player))
        {
            player.SetDamage();
        }
    }
}
