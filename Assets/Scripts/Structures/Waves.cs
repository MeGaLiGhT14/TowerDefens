using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{
    [SerializeField] private float _baseTimeBetweenWaves;
    private float _timeBetweenWaves;

    [SerializeField] private int _numberEnemiesInWave;

    [SerializeField] private float _baseTimeBetweenEnemiesInWave;
    private float _timeBetweenEnemiesInWave;

    [SerializeField] private bool _creatingWaves = false;

    private bool _enemyPreparing = false;
    private bool _wavePreparing = false;

    private int _counterEnemiesInWave = 0;
    private int _counterWaves = 0;
    public int CounterWaves => _counterWaves;

    [SerializeField] private IncreaseDifficulty _increaseDifficulty;
    private Spawn _spawn;

    private float _multiplierEnemyHealth = 1;

    [SerializeField] private TMP_Text _text;

    #region MonoBehaviour 

    private void OnValidate()
    {
        if (_baseTimeBetweenWaves < 0)
            _baseTimeBetweenWaves = 0;

        if (_baseTimeBetweenEnemiesInWave < 0)
            _baseTimeBetweenEnemiesInWave = 0;

        if (_numberEnemiesInWave < 1)
            _numberEnemiesInWave = 1;
    }

    private void Start()
    {
        _spawn = GetComponent<Spawn>();

        _text.text = "0";


        _timeBetweenWaves = _baseTimeBetweenWaves;
        _timeBetweenEnemiesInWave = _baseTimeBetweenEnemiesInWave;
    }

    private void Update()
    {
        if (_creatingWaves)
            if (!_wavePreparing)
                if (!_enemyPreparing)
                {
                    StartCoroutine(PrepareEnemy());

                    if (_counterEnemiesInWave == _numberEnemiesInWave)
                        StartCoroutine(PrepareWave());
                }
    }

    #endregion

    public void StartCreatingWaves()
    {
        _creatingWaves = true;
        _text.text = "1";
    }

    public void StopCreatingWaves()
    {
        _creatingWaves = false;
    }

    private IEnumerator PrepareEnemy()
    {
        _counterEnemiesInWave++;

        _enemyPreparing = true;
        yield return new WaitForSeconds(_timeBetweenEnemiesInWave);
        _spawn.CreateEnemy(_multiplierEnemyHealth);
        _enemyPreparing = false;
    }

    private IEnumerator PrepareWave()
    {
        _counterWaves++;

        _wavePreparing = true;
        yield return new WaitForSeconds(_timeBetweenWaves);
        _counterEnemiesInWave = 0;

        EndOfWave();
        _wavePreparing = false;
    }

    private void EndOfWave()
    {
        int multiplierCounter = _increaseDifficulty.MultiplierCounter;
        float difficultyMultiplier = _increaseDifficulty.DifficultyMultiplier;

        float multiplierTime = Mathf.Pow(difficultyMultiplier , multiplierCounter);
         multiplierTime = multiplierTime < 10 ? multiplierTime : 10;

        _timeBetweenWaves= _baseTimeBetweenWaves / multiplierTime;
        _timeBetweenEnemiesInWave =  _baseTimeBetweenEnemiesInWave / multiplierTime;

        _multiplierEnemyHealth = 1 + (difficultyMultiplier - 1) * multiplierCounter;

        _text.text = (_counterWaves + 1).ToString();
    }
}