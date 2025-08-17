using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameOverData
{
    public string date;
    public int score;
    public int wave;
    
}

[Serializable]
public class GameOverDataList
{
    public List<GameOverData> records = new List<GameOverData>();
}

public class SavingSystem : MonoBehaviour
{
    private static string filePath => Path.Combine(Application.persistentDataPath, "highscores.json");

    // Thêm 1 lần chơi vào file JSON
    public static void SaveGameOver(int score, int wave)
    {
        GameOverData newRecord = new GameOverData
        {
            date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            score = score,
            wave = wave
            
        };

        GameOverDataList dataList = LoadAllGameOvers();
        dataList.records.Add(newRecord);

        string json = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(filePath, json);

        Debug.Log("Saved Highscore: " + json);
    }

    // Load toàn bộ dữ liệu (list)
    public static GameOverDataList LoadAllGameOvers()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameOverDataList>(json);
        }
        else
        {
            return new GameOverDataList(); // rỗng nếu chưa có file
        }
    }
    public void ShowHighscores()
    {
        var allData = LoadAllGameOvers();

        // Sắp xếp theo điểm số giảm dần
        allData.records.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < Mathf.Min(5, allData.records.Count); i++)
        {
            var d = allData.records[i];
            Debug.Log($"#{i + 1} Score: {d.score} | Wave: {d.wave} | Date: {d.date}");
        }
    }

}
