using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackPanel : MonoBehaviour
{
    public void OnClickNo()
    {
        gameObject.active = false;
    }

    public void OnClickYes(string menu)
    {
        SceneManager.LoadScene(menu);
    }
}