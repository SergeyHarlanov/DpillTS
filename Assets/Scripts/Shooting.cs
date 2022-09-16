using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    public Action OnShooting;
    public  float bulletSpeed = 1;
    public float delayPush = 1;

    
   [SerializeField] protected List<Transform> _targets = new  List<Transform>();


    private bool isNowShooting;
    private bool _enemyZone;
    private void Update()
    {
        if (_targets.Count != 0 && !isNowShooting && _enemyZone)
        { 
            StartCoroutine(ShootSystem());
        }
    }

    private IEnumerator ShootSystem()
    {
        isNowShooting = true;
        while (_targets.Count != 0)
        {
            Debug.Log("shooting");

            OnShooting?.Invoke();
            yield return new WaitForSeconds(delayPush);
        }
        isNowShooting = false;
    }
    public Transform SelectEnemy()
    {
        if (!_targets[0].gameObject.activeSelf)
        {
            _targets.RemoveAt(0);
        }

        if (_targets.Count!=0)
        {
            return _targets[0];

        }
        return null;
    }

    public void RemoveEnemy(Transform enemyTransform)
    {
        _targets.Remove(enemyTransform);
    }

    public void EnemyZoneActive()
    {
        _enemyZone = true;
    }
    public void EnemyZoneDisActive()
    {
        _enemyZone = false;
    }
    //добавление врага в список
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Safe"))
        {
            _targets.Clear();
            Debug.Log("Clear");
        }

        if (other.CompareTag("Enemy"))
        {
            _targets.Add(other.transform);
        }
    }
    //удаление врага из списка
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _targets.Remove(other.transform);
        }
    }
    
}
