using TMPro;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _highScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowHighscores();
    }

    void ShowHighscores()
    {
        var allData = SavingSystem.LoadAllGameOvers();
        _highScoreText.text = "";
        // Sắp xếp theo điểm số giảm dần
        allData.records.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < Mathf.Min(5, allData.records.Count); i++)
        {
            var d = allData.records[i];
            _highScoreText.text += $"#{i + 1} Score: {d.score} | Wave: {d.wave} | Date: {d.date} \n ";
        }
    }
}
