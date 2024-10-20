using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private static string _lastScene;

        // Loads scene and gets name of previous scene
    public void LoadScene(string scene)
    {
        _lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

        // Loads last scene
    public void LoadLastScene()
    {
        SceneManager.LoadScene(_lastScene);
    }

        // Quits application with button
    public void Quit()
    {
        Application.Quit();
    }
}