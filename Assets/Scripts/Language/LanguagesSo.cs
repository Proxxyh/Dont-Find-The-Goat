using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LN", menuName = "ScriptableObjects/NewLanguage")]
public class LanguagesSo : ScriptableObject
{
    public string startButton;
    public string helpButton;
    public string exitButton;
    [Space]
    public string yesButton;
    public string noButton;
    [Space]
    public string ingameHeaderTextThreeDoorPickOne;
    public string ingameHeaderTextAskForTheChange;
    public string ingameHeaderTextTwoDoorPickOne;
    public string ingameHeaderTextWinText;
    public string ingameHeaderTextLoseText;
    [Space]
    public string helpWhatIsItHeader;
    [TextArea(1, 10)] public string helpWhatIsItText;
    public string helpMontyHallProblemHeader;
    [TextArea(1, 10)] public string helpMontyHallProblemText;



}
