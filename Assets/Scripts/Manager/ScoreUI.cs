using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _waveText;

    [SerializeField] private TextMeshProUGUI _gameOverText;



    private void Start()
    {
        if (_scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in the inspector!");
            return;
        }
        UpdateScoreUI();
        UpdateWaveUI();
    }

    public void UpdateScoreUI()
    {
        if (_scoreText == null) return;
        int score = GameManager.Instance.Score; // Assuming GetScore returns the current score
        _scoreText.text = "Score: " + score.ToString();

    }
    public void UpdateWaveUI()
    {
        if (_waveText == null) return;
        int wave = GameManager.Instance.Wave; // Assuming GetWave returns the current wave
        _waveText.text = "Wave: " + wave.ToString();
    }

    public void GameOverText()
    {
        if (_gameOverText == null ) return;
        int score = GameManager.Instance.Score; // Assuming GetScore returns the current score
        int wave = GameManager.Instance.Wave; // Assuming GetWave returns the current wave
        _gameOverText.text = "Score: " + score.ToString() + "  " + "Wave: " + wave.ToString();

    }
}
