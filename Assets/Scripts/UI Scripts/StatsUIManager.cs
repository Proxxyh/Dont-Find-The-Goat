using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StatsUIManager : MonoBehaviour
{
    public static StatsUIManager Instance;

    [SerializeField] public TMP_Text whenPlayerChangeDoorTitleTMP;
    [SerializeField] public TMP_Text whenPlayerChangeDoorStatsTMP;
    [SerializeField] public TMP_Text whenPlayerNotChangeDoorTitleTMP;
    [SerializeField] public TMP_Text whenPlayerNotChangeDoorStatsTMP;
    [SerializeField] public TMP_Text resetDataTMP;

    [SerializeField] private List<Color> colorList = new List<Color>();



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


        colorList.Add(this.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().color);
        colorList.Add(this.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>().color);
        colorList.Add(this.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>().color);
        colorList.Add(this.transform.GetChild(0).GetChild(4).GetComponent<TMP_Text>().color);
        colorList.Add(this.transform.GetChild(0).GetChild(5).GetComponent<TMP_Text>().color);
        colorList.Add(this.transform.GetChild(0).GetChild(6).GetComponent<Image>().color);
        colorList.Add(this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<TMP_Text>().color);
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
    public void ToggleMenu()
    {
        if (this.transform.GetChild(0).gameObject.activeSelf)
        {
            DOTween.KillAll();
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            TMP_Text tmpText;
            UnityEngine.UI.Image image = this.transform.GetChild(0).GetChild(6).GetComponent<UnityEngine.UI.Image>();

            float delay;


            this.transform.GetChild(0).gameObject.SetActive(true);

            delay = 0.5f;
            this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().DOScaleY(0, delay).From(); //BlackBack Anim

            tmpText = this.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
            tmpText.color = colorList[0];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.1f); //StatsTitle Anim

            tmpText = this.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
            tmpText.color = colorList[1];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.2f); //WhenPlayerChangeTitle Anim

            tmpText = this.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>();
            tmpText.color = colorList[2];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.2f); //WhenPlayerChangeStats Anim

            tmpText = this.transform.GetChild(0).GetChild(4).GetComponent<TMP_Text>();
            tmpText.color = colorList[3];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.4f); //WhenPlayerNotChangeTitle Anim

            tmpText = this.transform.GetChild(0).GetChild(5).GetComponent<TMP_Text>();
            tmpText.color = colorList[4];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.4f); //WhenPlayerNotChangeStats Anim


            image = this.transform.GetChild(0).GetChild(6).GetComponent<UnityEngine.UI.Image>();
            image.color = colorList[5];
            image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), delay + 1f).From().SetDelay(delay);

            tmpText = this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<TMP_Text>();
            tmpText.color = colorList[6];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 1).SetDelay(delay).From(); //WhenPlayerNotChangeStats Anim
        }
    }
    public void ToggleMenu(bool showOrHide)
    {
        if (!showOrHide)
        {
            DOTween.KillAll();
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if(showOrHide)
        {
            TMP_Text tmpText;
            UnityEngine.UI.Image image = this.transform.GetChild(0).GetChild(6).GetComponent<UnityEngine.UI.Image>();

            float delay;


            this.transform.GetChild(0).gameObject.SetActive(true);

            delay = 0.5f;
            this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().DOScaleY(0, delay).From(); //BlackBack Anim

            tmpText = this.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
            tmpText.color = colorList[0];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.1f); //StatsTitle Anim

            tmpText = this.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
            tmpText.color = colorList[1];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.2f); //WhenPlayerChangeTitle Anim

            tmpText = this.transform.GetChild(0).GetChild(3).GetComponent<TMP_Text>();
            tmpText.color = colorList[2];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.2f); //WhenPlayerChangeStats Anim

            tmpText = this.transform.GetChild(0).GetChild(4).GetComponent<TMP_Text>();
            tmpText.color = colorList[3];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.4f); //WhenPlayerNotChangeTitle Anim

            tmpText = this.transform.GetChild(0).GetChild(5).GetComponent<TMP_Text>();
            tmpText.color = colorList[4];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 0.5f).From().SetDelay(0.4f); //WhenPlayerNotChangeStats Anim


            image = this.transform.GetChild(0).GetChild(6).GetComponent<UnityEngine.UI.Image>();
            image.color = colorList[5];
            image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 0), delay + 1f).From().SetDelay(delay);

            tmpText = this.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<TMP_Text>();
            tmpText.color = colorList[6];
            tmpText.DOColor(new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, 0), delay + 1).SetDelay(delay).From(); //WhenPlayerNotChangeStats Anim
        }
    }

    public void StatsButton()
    {
        UpdateStatTexts();
        ToggleMenu();
    }
    public void ResetDataButton()
    {
        transform.Find("BlockPanel").gameObject.SetActive(true);
        transform.Find("YerOrNoBubble").gameObject.SetActive(true);
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
