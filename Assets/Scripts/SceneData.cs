using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;
    public string playerName;
    public int bestScoreNumber;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    class SaveScoreData
    {
       public int bestScoreNumber;
    }
    public void SaveBestScore()
    {
        SaveScoreData data = new SaveScoreData();
        data.bestScoreNumber = bestScoreNumber;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScoreData data = JsonUtility.FromJson<SaveScoreData>(json);

            bestScoreNumber = data.bestScoreNumber;
        }
    }
}
