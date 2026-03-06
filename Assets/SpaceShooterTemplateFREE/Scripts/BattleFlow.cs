using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;

    private bool isGameFinished = false; // Biến để đánh dấu trò chơi đã kết thúc

    public void ReturnToMainMenu() => SceneManager.LoadScene("New1");

    void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        if (playerHealth != null)
        {
            playerHealth.onDead += OnGameOver;
        }
    }

    void Update()
    {
        // Nếu game đã kết thúc thì không làm gì nữa
        if (isGameFinished) return;

        // Kiểm tra điều kiện thắng
        if (EnemyHealth.LivingEnemyCount <= 0)
        {
            OnGameWin();
        }
    }

    private void OnGameOver()
    {
        if (isGameFinished) return;
        isGameFinished = true;

        gameOverUI.SetActive(true);
        if (bgMusic != null) bgMusic.SetActive(false);
    }

    private void OnGameWin()
    {
        isGameFinished = true; // Đánh dấu đã thắng để Update ngừng gọi hàm này

        gameWinUI.SetActive(true);
        if (bgMusic != null) bgMusic.SetActive(false);

        // Kiểm tra an toàn trước khi truy cập playerHealth
        if (playerHealth != null && playerHealth.gameObject != null)
        {
            playerHealth.gameObject.SetActive(false);
        }
    }
}