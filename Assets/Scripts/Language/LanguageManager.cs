using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.PlayerSettings.Switch;
using System;

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

    public static Action OnLanguageChanged;


    [Header("Current")]
    [SerializeField] private Languages currentLanguageEnum;
    [SerializeField] public int currentLanguageIndex;
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
    [Space]
    [SerializeField] public TMP_Text whatIsItHeaderText;
    [SerializeField] public TMP_Text whatIsItDescriptionText;
    [SerializeField] public TMP_Text montyHallProblemText;
    [SerializeField] public TMP_Text montyHallProblemDescriptionText;
    [Space]
    [SerializeField] public TMP_Text statsTitleTMP;
    [Space]
    [SerializeField] public TMP_Text languageInitialTMP;



    [ContextMenu("Change Language")]
    public void ChangeLanguage()
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

        whatIsItHeaderText.text = currentLanguageSo.helpWhatIsItHeader;
        whatIsItDescriptionText.text = currentLanguageSo.helpWhatIsItText;
        montyHallProblemText.text = currentLanguageSo.helpMontyHallProblemHeader;
        montyHallProblemDescriptionText.text = currentLanguageSo.helpMontyHallProblemText;

        statsTitleTMP.text = currentLanguageSo.statsTitleText;

        languageInitialTMP.text = currentLanguageSo.languageInitialText;

        StatsUIManager.Instance.UpdateStatTexts();
        #endregion

    }

    public void ChangeLanguage(int languageIndex)
    {


        #region SetCurrentLanguageIndex
        currentLanguageIndex = languageIndex;
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

        whatIsItHeaderText.text = currentLanguageSo.helpWhatIsItHeader;
        whatIsItDescriptionText.text = currentLanguageSo.helpWhatIsItText;
        montyHallProblemText.text = currentLanguageSo.helpMontyHallProblemHeader;
        montyHallProblemDescriptionText.text = currentLanguageSo.helpMontyHallProblemText;

        statsTitleTMP.text = currentLanguageSo.statsTitleText;


        languageInitialTMP.text = currentLanguageSo.languageInitialText;

        //StatsUIManager.Instance.UpdateStatTexts();
        #endregion

    }



}
