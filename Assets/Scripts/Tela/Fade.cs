using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fade : MonoBehaviour
{
    Image painelFade;
    public bool goInAnyClick = true;
    public string levelToLoad = "Menu";
    public AudioSource source;
    bool fadeaudio = false;
    public static Fade fade;
    void Awake()
    {
        fade = this;
    }

    // Use this for initialization
    void Start()
    {
        painelFade = GetComponent<Image>();
        painelFade.enabled = true;
        painelFade.CrossFadeAlpha(0.01f, 5, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (goInAnyClick && Input.anyKeyDown)
        {
            painelFade.CrossFadeAlpha(1, 2, true);
            Invoke("ChangeScene", 2);
            fadeaudio = true;
        }
        if (fadeaudio)
        {
            source.volume = Mathf.Lerp(source.volume, 0, Time.deltaTime);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void ChangeScene(string level)
    {
        painelFade.CrossFadeAlpha(1, 2, true);
        levelToLoad = level;
        Invoke("ChangeScene", 2);
    }
}
