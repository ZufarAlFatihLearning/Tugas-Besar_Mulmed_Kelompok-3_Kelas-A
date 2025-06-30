using UnityEngine;
using UnityEngine.SceneManagement; // <-- JANGAN LUPA TAMBAHKAN INI

public class GameManagerMain : MonoBehaviour
{

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    // ... mungkin ada kode lain di sini ...

    // Buat fungsi ini agar bisa dipanggil oleh tombol
    public void KembaliKeMainMenu()
    {
        // Muat scene berdasarkan NAMA FILE SCENE nya
        SceneManager.LoadScene("MainMenu");
    }

    // Mungkin Anda juga butuh fungsi untuk memulai game dari Main Menu
    public void MulaiGame()
    {
        SceneManager.LoadScene("Game");
    }
}