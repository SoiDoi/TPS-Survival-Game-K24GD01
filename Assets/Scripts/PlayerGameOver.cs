using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    public void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
