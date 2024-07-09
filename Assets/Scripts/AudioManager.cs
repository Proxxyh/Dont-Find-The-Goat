using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    [SerializeField] private List<GameObject> audioObjects = new List<GameObject>();

    [Header("-----------------------------------------------------------------------------------------------------------------------------------------")]

    [Header("Music Settings")]
    [SerializeField] private AudioSource playSoundWithEnumSource;
    [SerializeField] private List<AudioClip> soundsWithEnum = new List<AudioClip>();

    [Header("-----------------------------------------------------------------------------------------------------------------------------------------")]

    [Header("Music Settings")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioClip> musics = new List<AudioClip>();
    [Space]
    [SerializeField] private int choosenMusicIndex;
    [SerializeField] private float currentTime;
    [SerializeField] private float choosenMusicLenght;


    private void Awake()
    {
        #region InstanceCheck
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        #endregion
    }
    private void OnEnable()
    {
        ChangeMusic();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= choosenMusicLenght)
        {
            ChangeMusic();
        }
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
        currentTime = 0;
        choosenMusicIndex = Random.Range(0, musics.Count);
        musicSource.clip = musics[choosenMusicIndex];
        choosenMusicLenght = musics[choosenMusicIndex].length;

        if (musicSource.gameObject.activeSelf)
        {
            musicSource.Play();
        }
        
        //StartCoroutine(MusicCounter());
    }

    private IEnumerator MusicCounter()
    {
        yield return new WaitForSeconds(choosenMusicLenght);
        ChangeMusic();
    }


    public void PlaySoundWithEnum(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.DoorPick:
                break;
            case SoundType.Win:
                break;
            case SoundType.Loose:
                break;
            default:
                break;
        }

        playSoundWithEnumSource.clip = soundsWithEnum[(int)soundType];
        if (playSoundWithEnumSource.gameObject.activeSelf)
        {
            playSoundWithEnumSource.Play();
        }
        
    }


}
public enum SoundType
{
    DoorPick,
    Win,
    Loose
}
