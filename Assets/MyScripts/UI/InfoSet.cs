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

    private void Start()
    {
        SetData(defaultInfo);
    }

    public void SetData(MissionInformation information)
    {
        number.text = "MISSION " + information.missionNumber;
        missionName.text = information.missionName;
        target.text = "�ڕW�F" + information.missionTarget;
        time.text = "�������ԁF" + information.missionTime;
        threat.text = "�G���Гx�F" + information.missionThreat;
        message.text = information.message;
        date.text = information.date;
    }
}
