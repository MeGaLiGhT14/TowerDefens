using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnButtonClick()
    {
        _animator.SetBool("IsOpen" , !_animator.GetBool("IsOpen"));
    }
}