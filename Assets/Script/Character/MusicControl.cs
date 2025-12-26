using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource bileþeni
    public AudioClip[] musicClips;  // Müzik listesi
    private int currentTrackIndex = 0; // Þu anki çalan müzik indeksi
    private bool isPlaying = true; // Müzik oynatma durumu

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Yalnýzca müzik oynatma aktifken sýradaki parçaya geç
        if (isPlaying && !audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        if (musicClips.Length == 0) return; // Eðer müzik yoksa çýk
        audioSource.clip = musicClips[currentTrackIndex]; // Þu anki parçayý ata
        audioSource.Play(); // Çalmaya baþla
        currentTrackIndex = (currentTrackIndex + 1) % musicClips.Length; // Döngüye sok
    }

    public void StartMusic()
    {
        if (!isPlaying)
        {
            isPlaying = true; // Oynatma durumunu aktif et
            if (!audioSource.isPlaying)
            {
                audioSource.Play();  // Yalnýzca müzik çalmýyorsa sýradaki parçayý çal
            }
        }
    }

    public void StopMusic()
    {
        if (isPlaying)
        {
            isPlaying = false; // Oynatma durumunu kapat
            audioSource.Stop(); // Mevcut müziði durdur
        }
    }
}
