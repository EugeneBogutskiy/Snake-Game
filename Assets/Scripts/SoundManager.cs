using UnityEngine;

public static class SoundManager

{
    public static void PlaySound()
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.01f;
        audioSource.PlayOneShot(GameAssets.gameAssets.snakeMove);
    }
}
