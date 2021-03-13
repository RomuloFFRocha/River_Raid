using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nomeDaCena;

    public void ChangeS()
    {
         SceneManager.LoadScene(sceneName: nomeDaCena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
