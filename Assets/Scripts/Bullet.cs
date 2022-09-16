using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
      //  StartCoroutine(DestroyMyself());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.SetDamage();
            StopAllCoroutines();
           Destroy(gameObject);
        }
      
    }

    private IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
