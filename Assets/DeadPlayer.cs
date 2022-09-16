using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Dead()
    {

        StartCoroutine(ResetLevel());
    }

    private IEnumerator ResetLevel()
    {
       // gameObject.SetActive(false);
       UIManager.Instance.ShowLostWindow();
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
