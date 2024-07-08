using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private List<GameObject> inMenuObjects = new List<GameObject>();


    #region SettingsButton
    public void OnClickSettingsButton()
    {
        TogglePanel();
    }
    private void TogglePanel()
    {
        if (inMenuObjects[0].activeSelf)    //Men�y� Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);
            }
        }
        else    //Men�y� A�
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);
            }
        }
    }
    private void TogglePanel(bool onOrOff)
    {
        if (!onOrOff)    //Men�y� Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);
            }
        }
        else if (onOrOff)   //Men�y� A�
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);
            }
        }
    }

    #endregion

    #region MenuItems

    public void ChangeLanguageButton()
    {
        LanguageManager.Instance.ChangeLanguage();
    }

    public void ToggleMusic()
    {

    }

    public void ToggleSounds()
    {

    }
    #endregion

}
