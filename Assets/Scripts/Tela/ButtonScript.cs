using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonScript : MonoBehaviour
{

    public Slider sliderMusic;
    public AudioMixer mixer;

    public void Play()
    {
       Fade.fade.ChangeScene("LevelSelect");
    }


    public void Fase1()
    {
        Fade.fade.ChangeScene("Level1");
    }

    public void Options()
    {
        Fade.fade.ChangeScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        Fade.fade.ChangeScene("Menu");
    }

    public void ChangeMusic()
    {
        mixer.SetFloat("volumemaster", (1 - sliderMusic.value) * -80);
    }
}
