using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("--Audio Source--")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioSource SFXLoop;

    [Header("--Audio Clip--")]
    public AudioClip mainMenu;
    public AudioClip inGame;
    public AudioClip ending;
    public AudioClip pause;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip buttonClick;
    public AudioClip collect;
    public AudioClip death;
    public AudioClip portal;
    public AudioClip popupMenu;
    public AudioClip sliderClick;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Music.clip = mainMenu;
        //Music.clip = inGame;
        Music.Play();
        SceneManager.activeSceneChanged += SceneChanged;
    }

    private void SceneChanged(Scene current, Scene next)
    {
        SFXLoop.Stop();
        switch (next.name)
        {
            case "Menu":
                ChangeBGM(mainMenu);
                break;

            case "Level1":
                ChangeBGM(inGame);
                break;

            case "Level2":
                ChangeBGM(inGame);
                break;

            case "Ending":
                ChangeBGM(ending);
                break;
        }
    }

    public void ChangeBGM(AudioClip music)
    {
        if (Music.clip.name == music.name) return;
        Music.Stop();
        Music.clip = music;
        Music.Play();
    }
    public void PlaySFX(string clip)
    {
        AudioClip audioClip;

        switch (clip)
        {
            case "Jump":
                audioClip = jump;
                break;

            case "ButtonClick":
                audioClip = buttonClick;
                break;

            case "Collect":
                audioClip = collect;
                break;

            case "Death":
                audioClip = death;
                break;

            case "Portal":
                audioClip = portal;
                break;

            case "PopupMenu":
                audioClip = popupMenu;
                break;

            case "SliderClick":
                audioClip = sliderClick;
                break;

            default:
                Debug.LogError("SFX is invalid");
                return;
        }
        SFX.clip = audioClip;
        SFX.Play();
    }

    public void PlaySFXLoop(string clip)
    {
        if (SFXLoop.isPlaying) return;
        SFXLoop.Stop();

        AudioClip audioClip;
        switch (clip)
        {
            case "Walk":
                audioClip = walk;
                break;

            default:
                Debug.LogError("SFX is invalid");
                return;
        }

        SFXLoop.clip = audioClip;
        SFXLoop.Play();
    }

    public void StopSFXLoop()
    {
        SFXLoop.Stop();
    }
}