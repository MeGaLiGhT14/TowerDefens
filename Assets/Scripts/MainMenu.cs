using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart(string lavalLabel)
    {
        SceneManager.LoadScene(lavalLabel);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
