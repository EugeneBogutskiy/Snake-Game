using UnityEngine;

public static class SoundManager

{
    public static void PlaySoundDead()
    {
        GameObject soundGameObject = new GameObject("SoundDead");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(GameAssets.gameAssets.snakeDead);
    }
}
