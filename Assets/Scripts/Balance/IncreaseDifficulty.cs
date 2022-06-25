using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{

    [SerializeField] private float _difficultyMultiplier;
    public float DifficultyMultiplier => _difficultyMultiplier;

    [SerializeField] private float _timeBetweenAmplification;

    private int _multiplierCounter = 0;
    public int MultiplierCounter => _multiplierCounter;

    #region MonoBehaviour 

    private void OnValidate()
    {
        if (_difficultyMultiplier < 1)
            _difficultyMultiplier = 1;

        if (_timeBetweenAmplification < 1)
            _timeBetweenAmplification = 1;
    }
    
    #endregion

    public void StartIncreasingDifficulty()
    {
        StartCoroutine(IncreasingDifficulty());
    }

    private IEnumerator IncreasingDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenAmplification);

            _multiplierCounter++;
        }
    }
}
