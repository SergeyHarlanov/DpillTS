using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private GameObject _cash;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void DeadMyself()
    {
        _cash.SetActive(true);
        _cash.transform.parent = null;
        gameObject.SetActive(false);
        EnemyManager.Instance.RemoveEnemy(_enemy);
        _enemy.playerTarget.GetComponent<Shooting>().RemoveEnemy(transform);
    }
}
