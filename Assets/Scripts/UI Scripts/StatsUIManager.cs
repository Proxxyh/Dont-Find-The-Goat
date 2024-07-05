using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StatsUIManager : MonoBehaviour
{
    public static StatsUIManager Instance;

    [SerializeField] public TMP_Text whenPlayerChangeDoorTitleTMP;
    [SerializeField] public TMP_Text whenPlayerChangeDoorStatsTMP;
    [SerializeField] public TMP_Text whenPlayerNotChangeDoorTitleTMP;
    [SerializeField] public TMP_Text whenPlayerNotChangeDoorStatsTMP;
    [SerializeField] public TMP_Text resetDataTMP;


    private LanguageManager languageManager;
    private ResultManager resultManager;
    private LanguagesSo so;

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
        languageManager = LanguageManager.Instance;
        resultManager = ResultManager.Instance;
        so = languageManager.currentLanguageSo;
    }

    [ContextMenu("Update Stat Texts")]
    public void UpdateStatTexts()
    {

        so = languageManager.currentLanguageSo;

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

        resetDataTMP.text = so.resetDataText;
    }


    public void StatsButton()
    {
        UpdateStatTexts();
        if (this.transform.GetChild(0).gameObject.activeSelf)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        


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
