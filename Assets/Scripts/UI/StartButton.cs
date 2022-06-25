using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private Waves _waves;
    [SerializeField] private IncreaseDifficulty _increaseDifficulty;

    public void OnButtonClick()
    {
        _waves.StartCreatingWaves();
        _increaseDifficulty.StartIncreasingDifficulty();

        gameObject.active = false;
    }
}