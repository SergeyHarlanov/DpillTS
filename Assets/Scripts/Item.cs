using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  Vector3 endval =transform.position + new Vector3(5, 5, 5);
       // transform.DOJump(endval, 10f, 100, 1, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.SetCubes();
            Destroy(gameObject);
        }
    }
}
