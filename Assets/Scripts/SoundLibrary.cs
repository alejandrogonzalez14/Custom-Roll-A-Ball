using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct SoundEffect
{
    public string groupID;
    public AudioClip[] clips;
}

public class SoundLibrary : MonoBehaviour
{
    // Using a dictionary for fast lookup
    private Dictionary<string, SoundEffect> soundEffectDictionary;

    public SoundEffect[] soundEffects;

    private void Awake()
    {
        // Initialize the dictionary on awake
        soundEffectDictionary = new Dictionary<string, SoundEffect>();

        // Populate the dictionary for faster lookup
        foreach (var soundEffect in soundEffects)
        {
            soundEffectDictionary[soundEffect.groupID] = soundEffect;
        }
    }

    public AudioClip GetClipFromName(string name)
    {
        // Check if the group ID exists in the dictionary
        if (soundEffectDictionary.ContainsKey(name))
        {
            var soundEffect = soundEffectDictionary[name];
            return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
        }
        return null; // Return null if group ID doesn't exist
    }
}
