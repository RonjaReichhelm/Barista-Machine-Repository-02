using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Pfade zum Soundfile
        string path = "Assets/Sounds/switch.mp3";
        AudioClip clip = Resources.Load<AudioClip>(path);

        // Überprüfe, ob das Soundfile gefunden wurde
        if (clip != null)
        {
            // Weise das Soundfile der AudioSource-Komponente zu
            audioSource.clip = clip;
        }
        else
        {
            Debug.LogError("Soundfile nicht gefunden: " + path);
        }
    }

    void OnMouseDown()
    {
        // Spiele den Sound ab, wenn das GameObject angeklickt wird
        audioSource.Play();
    }
}