using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public static SettingsPanel Instance;

    [SerializeField] public bool isMouseOnSettingsPanel;
    [SerializeField] public bool isSettingsPanelOpen;

    [SerializeField] private List<GameObject> inMenuObjects = new List<GameObject>();

    private void Awake()
    {
        #region InstanceCheck
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        #endregion
    }



    #region SettingsButton
    public void OnClickSettingsButton()
    {
        TogglePanel();
    }
    public void TogglePanel()
    {
        if (inMenuObjects[0].activeSelf)    //Men�y� Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);
                
            }
            isSettingsPanelOpen = false;
        }
        else    //Men�y� A�
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);
                
            }
            isSettingsPanelOpen = true;
        }
    }
    public void TogglePanel(bool onOrOff)
    {
        if (!onOrOff)    //Men�y� Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);
                
            }
            isSettingsPanelOpen = false;
        }
        else if (onOrOff)   //Men�y� A�
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);
                isSettingsPanelOpen = true;
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


    public void IsMouseOnSettingsPanel(bool onOrOff)
    {
        isMouseOnSettingsPanel = onOrOff;
    }

}
