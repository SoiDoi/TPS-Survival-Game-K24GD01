using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject playerPrefab; // Prefab của người chơi / Player prefab
    [SerializeField] private Transform spawnPoint; // Điểm xuất hiện của người chơi / Spawn point for player
    [SerializeField] private int _score = 0;
    [SerializeField] private int _wave = 0; // Số lượng wave hiện tại / Current wave number
    [SerializeField] private ScoreUI _scoreUI;

    [SerializeField] private GameObject _gameOver; // Giao diện Game Over / Game Over UI
    [SerializeField] private GameObject _scoreObj;
    [SerializeField] private CursorController _cursorController; // Quản lý con trỏ chuột / Cursor controller

    

    public int Score => _score; // Thuộc tính để lấy điểm số / Property to get score
    public int Wave => _wave; // Thuộc tính để lấy số lượng wave / Property to get wave count
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ GameManager khi chuyển cảnh / Keep GameManager when changing scenes
        }
        else
        {
            
            Destroy(gameObject); // Nếu đã có một GameManager, hủy đối tượng này /  Destroy this object if another GameManager already exists
        }
    }

    public void NewGame()
    {
        _cursorController.HideCursor(); // Ẩn con trỏ chuột khi bắt đầu game / Hide cursor when starting the game
        Time.timeScale = 1f; // Đặt thời gian về bình thường khi bắt đầu game / Set time scale to normal when starting the game
        if (_scoreObj != null) // Kiểm tra ScoreUI không null / Check if ScoreUI is not null
        {
            _scoreObj.SetActive(true);
        }
        else
        {
            Debug.LogWarning("ScoreUI is not assigned!"); // Cảnh báo nếu ScoreUI chưa gán / Warning if ScoreUI is not assigned
        }
        if (_gameOver != null) // Kiểm tra Game Over UI không null / Check if Game Over UI is not null
        {
            _gameOver.SetActive(false); // Hiển thị giao diện Game Over / Show Game Over UI
        }
        else
        {
            Debug.LogWarning("Game Over UI is not assigned!"); // Cảnh báo nếu Game Over UI chưa gán / Warning if Game Over UI is not assigned
        }
        _score = 0;
        _scoreUI.UpdateScoreUI();
        _wave = 0;
        _scoreUI.UpdateWaveUI();
    }


    public void GetScore(int score) // Lấy điểm số / Get score
    {
        if (score < 0) // Kiểm tra điểm số không âm / Check if score is not negative
        {
            Debug.LogWarning("Score cannot be negative!"); // Cảnh báo nếu điểm số âm / Warning if score is negative
            return;
        }
        _score += score; // Cộng điểm vào tổng điểm / Add score to total score
        if (_scoreUI != null) // Kiểm tra ScoreUI không null / Check if ScoreUI is not null
        {
            _scoreUI.UpdateScoreUI(); // Cập nhật giao diện điểm số / Update score UI
        }
        else
        {
            Debug.LogWarning("ScoreUI is not assigned!"); // Cảnh báo nếu ScoreUI chưa gán / Warning if ScoreUI is not assigned
        }
    }

    public void NextWave() // Hàm để chuyển sang wave tiếp theo / Function to go to the next wave
    {
        _wave++; // Tăng số lượng wave lên 1 / Increase wave count by 1
        if(_scoreUI != null) // Kiểm tra ScoreUI không null / Check if ScoreUI is not null
        {
            _scoreUI.UpdateWaveUI(); // Cập nhật giao diện wave / Update wave UI
        }
        else
        {
            Debug.LogWarning("ScoreUI is not assigned!"); // Cảnh báo nếu ScoreUI chưa gán / Warning if ScoreUI is not assigned
        }
    }

    public void GameOver()
    {
        _cursorController.ShowCursor(); // Hiện con trỏ chuột khi game over / Show cursor when game over
        //Time.timeScale = 0f; // Dừng thời gian khi game over / Stop time when game over
        if (_scoreObj != null) // Kiểm tra ScoreUI không null / Check if ScoreUI is not null
        {
            _scoreObj.SetActive(false);
        }
        else
        {
            Debug.LogWarning("ScoreUI is not assigned!"); // Cảnh báo nếu ScoreUI chưa gán / Warning if ScoreUI is not assigned
        }
        if (_gameOver != null) // Kiểm tra Game Over UI không null / Check if Game Over UI is not null
        {
            _gameOver.SetActive(true); // Hiển thị giao diện Game Over / Show Game Over UI
        }
        else
        {
            Debug.LogWarning("Game Over UI is not assigned!"); // Cảnh báo nếu Game Over UI chưa gán / Warning if Game Over UI is not assigned
        }
        _scoreUI.GameOverText();
        SavingSystem.SaveGameOver(_score, _wave);
    }
    

}
