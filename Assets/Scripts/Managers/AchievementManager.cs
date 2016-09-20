using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }
    public Text[] acText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Initialize()
    {
        if (DataManager.ReadIntData(DataManager.acOne) == 1)
            acText[0].text = "Status: Completed";
        else
            acText[0].text = "Status: Not Achieved";

        if (DataManager.ReadIntData(DataManager.acTwo) == 1)
            acText[1].text = "Status: Completed";
        else
            acText[1].text = "Status: Not Achieved";

        if (DataManager.ReadIntData(DataManager.acThree) == 1)
            acText[2].text = "Status: Completed";
        else
            acText[2].text = "Status: Not Achieved";
    }

    public void Reset()
    {
        DataManager.StoreIntData(DataManager.acOne, 0);
        DataManager.StoreIntData(DataManager.acTwo, 0);
        DataManager.StoreIntData(DataManager.acThree, 0);
        Initialize();
    }
}
