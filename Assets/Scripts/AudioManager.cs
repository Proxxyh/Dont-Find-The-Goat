using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> audioObjects = new List<GameObject>();

    [Header("-----------------------------------------------------------------------------------------------------------------------------------------")]

    [Header("Music Settings")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioClip> musics = new List<AudioClip>();
    [Space]
    [SerializeField] private int choosenMusicIndex;
    [SerializeField] private float choosenMusicLenght;

    private void OnEnable()
    {
        ChangeMusic();
    }

    public void OneShotAudio(GameObject audioObject)
    {
        if (audioObject.activeSelf)
        {
            audioObject.GetComponent<AudioSource>().Play();
        }
    }


    public void ToggleAudios()
    {
        if (audioObjects[0].activeSelf)
        {
            foreach (GameObject item in audioObjects)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject item in audioObjects)
            {
                item.SetActive(true);
            }
        }

    }
    public void ToggleMusics()
    {
        if (musicSource.gameObject.activeSelf)
        {
            musicSource.gameObject.SetActive(false);
        }
        else
        {
            musicSource.gameObject.SetActive(true);
            ChangeMusic();
        }

    }


    [ContextMenu("Change Music")]
    private void ChangeMusic()
    {
        choosenMusicIndex = Random.Range(0, musics.Count);
        musicSource.clip = musics[choosenMusicIndex];
        choosenMusicLenght = musics[choosenMusicIndex].length;

        musicSource.Play();
        StartCoroutine(MusicCounter());
    }

    private IEnumerator MusicCounter()
    {
        yield return new WaitForSeconds(choosenMusicLenght);
        ChangeMusic();
    }
}
