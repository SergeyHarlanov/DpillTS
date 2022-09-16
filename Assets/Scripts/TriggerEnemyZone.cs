using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyZone : MonoBehaviour
{
    [HideInInspector] public bool moveEnemy;
    private List<Enemy> _enemyList = new  List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        _enemyList.Add(enemy);
    }

    public void RemoveEnemyFromList(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }

    private void Update()
    {
        if (moveEnemy) _enemyList.ForEach(x=>x.Move());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Shooting>(out Shooting shooting))
        {
            shooting.EnemyZoneActive();
            _enemyList.ForEach((x) => x.StartMove());
            moveEnemy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Shooting>(out Shooting shooting))
        {
            shooting.EnemyZoneDisActive();
            _enemyList.ForEach((x) => x.Stop());
            moveEnemy = false;
        }
    }
}
