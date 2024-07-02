using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HideAndShowText : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float hideValue;
    [SerializeField] private float showValue;
    [SerializeField] private bool canShowTexts;
    [SerializeField] private List<TMP_Text> texts = new List<TMP_Text>();
    [SerializeField] private List<Color> colors = new List<Color>();

    private void Start()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            colors.Add(texts[i].color);
        }
    }


    private void LateUpdate()
    {

        if (canShowTexts)
        {
            ShowTexts();
        }
        else
        {
            HideTexts();
        }
    }

    public void MouseEnterText()
    {
        canShowTexts = true;
    }
    public void MouseExitText()
    {
        canShowTexts = false;
    }


    void HideTexts()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i].DOColor(new Color(colors[i].r, colors[i].g, colors[i].b, hideValue), duration);
        }
    }

    void ShowTexts()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i].DOColor(new Color(colors[i].r, colors[i].g, colors[i].b, showValue), duration);
        }
    }

}
