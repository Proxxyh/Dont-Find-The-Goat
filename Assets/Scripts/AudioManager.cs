using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> audioObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> musicObjects = new List<GameObject>();


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
        if (musicObjects[0].activeSelf)
        {
            foreach (GameObject item in musicObjects)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject item in musicObjects)
            {
                item.SetActive(true);
            }
        }

    }
}
