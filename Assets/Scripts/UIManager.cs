using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI _cubesField;
    [SerializeField] private Slider _hpBarPlayer;
    [SerializeField] private GameObject _lostwindow;
    void Start()
    {
        Instance = this;
    }

    public void InitialCubesText(int countCubes)
    {
        _cubesField.text = countCubes.ToString();
    }
    public void ShowLostWindow()
    {
        _lostwindow.SetActive(true);
    }

    public void InitialHpBarPlayer( float hp)
    {
        _hpBarPlayer.value = hp;
    }
}
