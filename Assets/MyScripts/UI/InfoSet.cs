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
        target.text = "目標：" + information.missionTarget;
        time.text = "制限時間：" + information.missionTime;
        threat.text = "敵脅威度：" + information.missionThreat;
        message.text = information.message;
        date.text = information.date;
    }
}
