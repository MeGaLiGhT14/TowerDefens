using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnClickHelp()
    {
        _animator.SetBool("IsOpen" , true);
    }

    public void OnClickOk()
    {
        _animator.SetBool("IsOpen" , false);
    }
}