using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoSet : MonoBehaviour
{
    [SerializeField] MissionInformation defaultInfo;
    [SerializeField] TextMeshProUGUI number;
    [SerializeField] TextMeshProUGUI missionName;
    [SerializeField] TextMeshProUGUI target;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI threat;
    [SerializeField] TextMeshProUGUI message;
    [SerializeField] TextMeshProUGUI date;
    [SerializeField] TextMeshProUGUI highScore;

    private void Start()
    {
        SetData(defaultInfo);
    }

    public void SetData(MissionInformation information)
    {
        if (SaveManager.save.highScores.Length >= information.missionValue)
        {
            highScore.text = "�n�C�X�R�A�F" + SaveManager.save.highScores[information.missionValue].ToString();
        }
        else
        {
            highScore.text = "�n�C�X�R�A�F0";
        }

        number.text = "MISSION " + information.missionNumber;
        missionName.text = information.missionName;
        target.text = "�B�������F" + information.missionTarget;
        time.text = "�������ԁF" + information.missionTime;
        threat.text = "�G���Гx�F" + information.missionThreat;
        message.text = information.message;
        date.text = information.date;
    }
}
