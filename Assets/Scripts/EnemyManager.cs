using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private Transform _playerTransform;
    
    [Header("Property Managers")]
    [SerializeField] private Vector3 _sizeZoneSpawner = Vector3.zero;
    [SerializeField] private float _delaySpawn = 3;
   
    private TriggerEnemyZone _triggerEnemyZone;

    public void RemoveEnemy(Enemy enemy)
    {
        _triggerEnemyZone.RemoveEnemyFromList(enemy);
    }
    private void Start()
    {
        Instance = this;
        
        _triggerEnemyZone = GetComponent<TriggerEnemyZone>();
            
        StartCoroutine(SpawnerEnemy());
    }

    private IEnumerator SpawnerEnemy()
    {
        while (true)
        {
            //рандомный спавн
            float xRand = Random.Range(-_sizeZoneSpawner.x / 2, _sizeZoneSpawner.x / 2);
            float zRand = Random.Range(-_sizeZoneSpawner.z / 2, _sizeZoneSpawner.z / 2);
            Vector3 randPos =new Vector3(xRand, transform.position.y, zRand );
            Enemy enemy =  Instantiate(_prefabEnemy, randPos,Quaternion.identity ).GetComponent<Enemy>();
            enemy.playerTarget = _playerTransform;
            
            _triggerEnemyZone.AddEnemy(enemy);
            
            if (_triggerEnemyZone.moveEnemy)
            {
                enemy.StartMove();
            }
            yield return new WaitForSeconds(_delaySpawn);
        }
    }
    
    //зона спавна противников
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.position, _sizeZoneSpawner);
    }

}
