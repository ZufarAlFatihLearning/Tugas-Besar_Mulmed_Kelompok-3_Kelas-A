using UnityEngine;
using TMPro; // Tetap perlukan ini untuk mengontrol teks
using UnityEngine.SceneManagement;
using UnityEngine.SearchService;

public class GameOverScreen : MonoBehaviour
{
    // Kita masih butuh referensi ke komponen Teks, tapi kita ganti namanya agar lebih jelas
    [SerializeField] private TextMeshProUGUI gameOverText;

    // Fungsi Setup sekarang tidak lagi memerlukan parameter skor
    public void Setup()
    {
        // 1. Aktifkan panel Game Over
        gameObject.SetActive(true);

        // 2. Langsung atur teks yang ditampilkan menjadi "GAME OVER"
        if (gameOverText != null)
        {
            gameOverText.text = "GAME OVER";
        }

        // 3. Hentikan waktu
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}