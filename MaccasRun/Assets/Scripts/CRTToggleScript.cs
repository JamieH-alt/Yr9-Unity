using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRTToggleScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject _CRTVolume;
    public bool CRTActive = true;

    public static CRTToggleScript instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        DataPersistentManager.instance.LoadGame();
        CRTVolume(CRTActive);
    }
    
    public void LoadData(GameData data)
    {
        CRTActive = data.CRTActive;
        _CRTVolume.SetActive(CRTActive);
    }

    public void SaveData(ref GameData data)
    {
        data.CRTActive = CRTActive;
    }

    public void CRTVolume(bool onoff) {
        _CRTVolume.SetActive(onoff);
        CRTActive = onoff;
        DataPersistentManager.instance.SaveGame();
    }
}
