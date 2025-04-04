using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    private void Start()
    {
        MusicManager.Instance.PlayMusic("bg", 0.0f);
    }

    // Moves to Minigame scene after a delay
    public void Play()
    {
        StartCoroutine(PlayWithDelay());
    }

    // Exits the game after a delay
    public void Exit()
    {
        StartCoroutine(ExitWithDelay());
    }

    private IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(0.5f);  // Wait for 0.5 seconds
        SceneManager.LoadScene("Minigame");     // Load the scene
    }

    private IEnumerator ExitWithDelay()
    {
        yield return new WaitForSeconds(0.5f);  // Wait for 0.5 seconds
#if UNITY_EDITOR
        // Stop playing in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application (works in the built game)
        Application.Quit();
#endif
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
