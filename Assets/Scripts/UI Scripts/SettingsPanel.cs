using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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
    private void Start()
    {
        languageTMPColor = transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().color;
    }



    #region SettingsButton
    public void OnClickSettingsButton()
    {
        TogglePanel();
    }
    public void TogglePanel()
    {
        if (inMenuObjects[0].activeSelf)    //Menüyü Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);

            }
            isSettingsPanelOpen = false;
        }
        else    //Menüyü Aç
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);

            }
            isSettingsPanelOpen = true;
            StartAnimations();
        }
    }
    public void TogglePanel(bool onOrOff)
    {
        if (!onOrOff)    //Menüyü Kapat
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(false);

            }
            isSettingsPanelOpen = false;
        }
        else if (onOrOff)   //Menüyü Aç
        {
            foreach (GameObject item in inMenuObjects)
            {
                item.SetActive(true);
                isSettingsPanelOpen = true;
            }
        }
    }

    private Color languageTMPColor;
    public void StartAnimations()
    {
        DOTween.KillAll();

        transform.GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        transform.GetChild(0).GetComponent<RectTransform>().DOScaleY(0, 0.5f).From(); //BlackBack Anim

        transform.GetChild(1).GetComponent<Image>().color = Color.white;
        transform.GetChild(1).GetComponent<Image>().DOColor(new Color(1,1,1,0), 0.5f).From().SetDelay(0.1f);

        transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().color = languageTMPColor;
        transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().DOColor(new Color(languageTMPColor.r, languageTMPColor.g, languageTMPColor.b, 0), 0.5f).From().SetDelay(0.1f);

        transform.GetChild(2).GetComponent<Image>().color = Color.white;
        transform.GetChild(2).GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 0.5f).From().SetDelay(0.2f);

        transform.GetChild(3).GetComponent<Image>().color = Color.white;
        transform.GetChild(3).GetComponent<Image>().DOColor(new Color(1, 1, 1, 0), 0.5f).From().SetDelay(0.3f);


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
