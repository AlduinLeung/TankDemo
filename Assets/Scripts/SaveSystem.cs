using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "PlayerHealth", sceneKey = "SceneIndex", savePresentKey = "SavePresent";
    public LoadedData LoadedData {get; private set;}
    public UnityEvent<bool> OnDataLoadedResult;
     private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        // bool result = LoadData();
        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);
    }
    // reset key and delete data
    public void ResetData()
    {
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        LoadedData = null;
    }

    // check data is present or not
    public bool LoadData()
    {

        if (PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            LoadedData = new LoadedData();
            LoadedData.playerHealth = PlayerPrefs.GetInt(playerHealthKey);
            LoadedData.sceneIndex = PlayerPrefs.GetInt(sceneKey);
            return true;
        }
        return false;

    }
    // passing scene index and player health to save data
    public void SaveData(int sceneIndex, int playerHealth)
    {
        if (LoadedData == null)
            LoadedData = new LoadedData();
        LoadedData.playerHealth = playerHealth;
        LoadedData.sceneIndex = sceneIndex;
        PlayerPrefs.SetInt(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex);
        PlayerPrefs.SetInt(savePresentKey, 1);
    }
}


// loaded data class Object
public class LoadedData {
    public int playerHealth =-1 ;
    public int sceneIndex= -1;
    public bool savePresent;
} 