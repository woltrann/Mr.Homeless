using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound; // Project kýsmýndaki ses dosyasý
    private AudioSource audioSource;
    public InputField ParaKoyBarbut;
    private int paraKoyBarbut;
    void Start()
    {
        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        int.TryParse(ParaKoyBarbut.text, out paraKoyBarbut);
        if (paraKoyBarbut >= 50)
        {
            // Ses çalma iþlemi
            if (buttonClickSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(buttonClickSound);
            }
        }
        
        
    }
}
