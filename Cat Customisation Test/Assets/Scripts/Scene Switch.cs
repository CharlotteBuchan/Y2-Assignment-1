using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private static string lastScene;
    public AudioSource buttonSound;

    public void Start()
    {
        buttonSound = GameObject.Find("Button Effects").GetComponent<AudioSource>();
    }
    // Loads scene and gets name of previous scene
    public void LoadScene(string scene)
    {
        lastScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(scene);
        StartCoroutine(LoadWithDelay(scene, 0.4f));
    }

        // Loads last scene
    public void LoadLastScene()
    {
        //SceneManager.LoadScene(lastScene);
        StartCoroutine(LoadWithDelay(lastScene, 0.4f));
    }

        // Quits application with button
    public void Quit()
    {
        Application.Quit();
    }

    public void ButtonSound()
    {
        buttonSound.Play();
    }
    public IEnumerator LoadWithDelay(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name);
    }
}