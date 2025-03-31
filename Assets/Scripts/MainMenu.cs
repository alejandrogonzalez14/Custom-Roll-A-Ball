using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Moves to Minigame scene
    public void Play()
    {
        SceneManager.LoadScene("Minigame");
    }

    // Exits the game when 'Exit' Button is clicked
    public void Exit()
    {
    #if UNITY_EDITOR
        // Stop playing in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // Quit the application (works in the built game)
        Application.Quit();
    #endif
    }
}
