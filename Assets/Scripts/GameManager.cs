using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string nickName;
    public Text bestScore;
    public int bestScoreNum;
    public GameObject inputField;
    public ExitScript loadFunction;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void StoreName()
    {
        nickName = inputField.GetComponent<Text>().text;
    }

    public void StartGame()
    {
        StoreName();
        SceneManager.LoadScene(1);
        Debug.Log(bestScore.text);
        
    }

    [System.Serializable]
    class SaveData
    {
        public Text bestScore;
        public int bestScoreNum;
    }


    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestScoreNum = bestScoreNum;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestScoreNum = data.bestScoreNum;
        }
    }
}
