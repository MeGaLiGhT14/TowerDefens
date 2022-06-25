using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    private void Start()
    {
        Slider _slider = GetComponent<Slider>();
        AudioListener.volume = _slider.value;
    }

    public void OnAudioChanged(float volume)
    {
        AudioListener.volume = volume;
    }
}