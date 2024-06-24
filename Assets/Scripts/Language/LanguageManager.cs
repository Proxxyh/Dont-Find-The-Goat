using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.PlayerSettings.Switch;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;
    private void Awake()
    {
        #region InstanceCheck
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        #endregion
    }


    [Header("Current")]
    [SerializeField] private Languages currentLanguageEnum;
    [SerializeField] private int currentLanguageIndex;
    [SerializeField] public LanguagesSo currentLanguageSo;

    [Header("Languages SO")]
    [SerializeField] public List<LanguagesSo> allLanguagesSoList;

    [Header("All Texts")]
    [SerializeField] public TMP_Text ingameHeaderText;
    [Space]
    [SerializeField] public TMP_Text mainMenuStartText;
    [SerializeField] public TMP_Text mainMenuHelpText;
    [SerializeField] public TMP_Text mainMenuExitText;
    [Space]
    [SerializeField] public TMP_Text yesText;
    [SerializeField] public TMP_Text noText;



    [ContextMenu("Change Language")]
    void ChangeLanguage()
    {
        #region SetCurrentLanguageIndex
        if (currentLanguageIndex + 1 < allLanguagesSoList.Count)
        {
            currentLanguageIndex++;
        }
        else
        {
            currentLanguageIndex = 0;
        }
        #endregion

        #region SetCurrentLanguageEnum
        currentLanguageEnum = (Languages)currentLanguageIndex;
        #endregion

        #region SetCurrentLanguageSo
        currentLanguageSo = allLanguagesSoList[currentLanguageIndex];
        #endregion


        #region SetTexts
        mainMenuStartText.text = currentLanguageSo.startButton;
        mainMenuHelpText.text = currentLanguageSo.helpButton;
        mainMenuExitText.text = currentLanguageSo.exitButton;

        yesText.text = currentLanguageSo.yesButton;
        noText.text = currentLanguageSo.noButton;
        #endregion
    }
}
