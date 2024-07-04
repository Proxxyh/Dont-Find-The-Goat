using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StatsUIManager : MonoBehaviour
{

    [SerializeField] public TMP_Text whenPlayerChangeDoorTitleTMP;
    [SerializeField] public TMP_Text whenPlayerChangeDoorStatsTMP;
    [SerializeField] public TMP_Text whenPlayerNotChangeDoorTitleTMP;
    [SerializeField] public TMP_Text whenPlayerNotChangeDoorStatsTMP;


    private LanguageManager languageManager;
    private ResultManager resultManager;

    private void Awake()
    {

    }
    private void OnEnable()
    {

        
    }
    private void Start()
    {
        languageManager = LanguageManager.Instance;
        resultManager = ResultManager.Instance;
    }

    [ContextMenu("Update Stat Texts")]
    public void UpdateStatTexts()
    {
        print("Güncelledim");

        LanguagesSo so = languageManager.currentLanguageSo;

        whenPlayerChangeDoorTitleTMP.text = so.changeDoorText;
        whenPlayerChangeDoorStatsTMP.text =
            so.winsText + ": " + resultManager.playerChangeDoorWinTotal + "\n" +
            so.loosesText + ": " + (resultManager.playerChangeDoorAllTotal - resultManager.playerChangeDoorWinTotal) + "\n" +
            so.totalText + ": " + resultManager.playerChangeDoorAllTotal + "\n" +
            so.rateText + ": %" + resultManager.playerChangeDoorPercent.ToString("F2");
        


        whenPlayerNotChangeDoorTitleTMP.text = so.notChangeDoorText;
        whenPlayerNotChangeDoorStatsTMP.text =
            so.winsText + ": " + resultManager.playerNotChangeDoorWinTotal + "\n" +
            so.loosesText + ": " + (resultManager.playerNotChangeDoorAllTotal - resultManager.playerNotChangeDoorWinTotal) + "\n" +
            so.totalText + ": " + resultManager.playerNotChangeDoorAllTotal + "\n" +
            so.rateText + ": %" + resultManager.playerNotChangeDoorPercent.ToString("F2");
    }


    public void StatsButton()
    {
        UpdateStatTexts();
    }
    public void ResetDataButton()
    {

    }
    public void ResetDataYesButton()
    {
        SaveManager.Instance.ResetAllPlayerPrefs();
        resultManager.ClearResultManagerVariables();

        UpdateStatTexts();
    }
    public void ResetDataNoButton()
    {

    }
}
