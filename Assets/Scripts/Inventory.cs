using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public int CountCubes { get; private set; }

    private int _cubeinInventory;
    [SerializeField] private Transform _spaceForInventItem;
    [SerializeField] private int _maxSizeinvent;

 private void Start()
 {
     Instance = this;
 }

 public void SetCubes()
 {
     if (_maxSizeinvent>_cubeinInventory)
     {
         _spaceForInventItem.GetChild(_cubeinInventory).gameObject.SetActive(true);
         _cubeinInventory += 1;
         Debug.Log(CountCubes);
     }
 }

 private void ResetCube()
 {
     _cubeinInventory = 0;
     foreach (Transform item in _spaceForInventItem)
     {
         item.gameObject.SetActive(false);
     }
 }
 private void OnTriggerEnter(Collider other)
 {
     if (other.CompareTag("Safe"))
     {
         CountCubes += _cubeinInventory;

         UIManager.Instance.InitialCubesText(CountCubes);
         
         ResetCube();
         
     }
 }
}
