using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuAudio : MonoBehaviour
{
    public AudioSource audio;

    public static MenuAudio instance;

    public string sceneName;

    static bool AudioBegin = false;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        if (!AudioBegin)
        {
            audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    void Update()
    {
        if (sceneName == "Menu" || sceneName == "Store")
        {
            audio.Stop();
            AudioBegin = false;
        }
    }
}
