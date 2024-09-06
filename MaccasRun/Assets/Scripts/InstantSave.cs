using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSave : MonoBehaviour
{
    public void Save() {
        DataPersistentManager.instance.SaveGame();
    }
}
