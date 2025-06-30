using UnityEngine;

public class GerindaMuter : MonoBehaviour
{
    [SerializeField] private float kecepatanPutaran = 360f;

    private PlayerMovement komponenPemain;
    private AudioManager audioManager;

    private void Awake()
    {
        // 1. Cari GameObject Player bernama "Kodok" dan ambil script PlayerMovement-nya
        // Simpan ke dalam variabel agar tidak perlu mencari terus-menerus
        GameObject playerObject = GameObject.Find("Kodok");
        if (playerObject != null)
        {
            komponenPemain = playerObject.GetComponent<PlayerMovement>();
        }

        // 2. Cari GameObject dengan tag "Audio" dan ambil script AudioManager-nya
        GameObject audioManagerObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
    }

    // Fungsi ini akan berjalan ketika ada objek lain yang masuk ke trigger musuh ini
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang masuk memiliki tag "Player"
        if (other.CompareTag("Player"))
        {
            // Jika benar Player, lakukan semua aksi di bawah ini:

            // Aksi 1: Kurangi nyawa pemain
            // Pastikan referensi ke pemain tidak kosong untuk menghindari error
            if (komponenPemain != null)
            {
                komponenPemain.nyawa--;
            }

            // Aksi 2: Mainkan audio
            // Pastikan referensi ke audio manager tidak kosong
            if (audioManager != null)
            {
                // Hentikan musik latar
                audioManager.StopMusic(); // atau Anda bisa gunakan: audioManager.MuteMusic(true);

                // Mainkan suara efek kematian
                audioManager.PlaySFX(audioManager.death);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, kecepatanPutaran * Time.deltaTime);
    }
}