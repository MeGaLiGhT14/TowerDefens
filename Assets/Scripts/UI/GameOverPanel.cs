using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _textNumberWaves;

    [SerializeField] private Waves _waves;

    public void OnClickOk(string menu)
    {
        SceneManager.LoadScene(menu);
    }

    public void GameOver()
    {
        _waves.StopCreatingWaves();
        _textNumberWaves.text = (_waves.CounterWaves + 1).ToString();

        gameObject.active = true;

        Animator animator = GetComponent<Animator>();
        animator.SetBool("IsOpen" , true);
    }
}