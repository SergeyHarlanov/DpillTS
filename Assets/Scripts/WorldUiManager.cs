using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUiManager : MonoBehaviour
{
    [SerializeField] private List<itemUILookCamera> _uiSystems = new  List<itemUILookCamera>();

    [SerializeField] private Vector3 _offset;



    // Update is called once per frame
    void Update()
    {
        foreach (var item in _uiSystems)
        {
            item.uiItem.transform.position = item.player.position + _offset;
        }
    }
}