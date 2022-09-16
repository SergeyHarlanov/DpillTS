using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
  
    [SerializeField] private float _speed = 1;
    [SerializeField] private int _hp = 100;
   
    
    [Header("Property")]
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spaceSpawnBullet;

    private CharacterController _characterController;
    private Animator _animator;
    private Shooting _shooting;
    private DeadPlayer _deadPlayer;
    
    private int _hpStart;
    void Start()
    {
        Application.targetFrameRate = 60;
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _shooting = GetComponent<Shooting>();
        _deadPlayer = GetComponent<DeadPlayer>();
        
        _shooting.OnShooting +=()=> Attack();
        
        _hpStart = _hp;
    }

    public  void Move()
    {
        Vector3 dir = new Vector3(_fixedJoystick.Horizontal, 0, _fixedJoystick.Vertical);
        if (dir.magnitude != 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            _characterController.Move(transform.forward * _speed);
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }

    public  void Attack()
    {
        if (_shooting.SelectEnemy())
        {
        Rigidbody bulletRb = Instantiate(_bulletPrefab,_spaceSpawnBullet.position ,Quaternion.identity ).GetComponent<Rigidbody>();
        Vector3 dir = ((_shooting.SelectEnemy().position + new  Vector3(0, 0.5f, 0))-_spaceSpawnBullet.position).normalized;
        bulletRb.velocity = (dir * _shooting.bulletSpeed);
        }
    }
 
    public void SetDamage()
    {
        _hp--;
        UIManager.Instance.InitialHpBarPlayer( GetPercent(_hpStart, _hp));
        if (_hp <=0)
        {
            _deadPlayer.Dead();
        }
    }
    private void Update()
    {
        Move();
    }
    public  Int32 GetPercent(Int32 b, Int32 a)
    {
        if (b == 0) return 0;
     
        return (Int32)( a / (b / 100M));
    }
}