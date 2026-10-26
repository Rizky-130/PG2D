using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] AudioSource collectAudioSource;
    int score = 0;
    int missed = 0;
    string pesan = "Klik Sampah Seblum Jatuh";

    void Awake()
    {
        if (collectAudioSource == null)
        {
            collectAudioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayCollectSound(AudioClip clip, float volumeScale)
    {
        if (collectAudioSource != null && clip != null)
        {
            collectAudioSource.PlayOneShot(clip, volumeScale);
        }
    }

    public void AddPoints(int nilai, string info)
    {
        score+=nilai;
        pesan = info;
    }

    public void AddMissed()
    {
        missed++;
        pesan = "Sampah Terlewat, Lingkungan Tercemar";
    }
    void OnGUI() {
        //tambahkan panel
        GUI.Box(new Rect(10,10,400,100), "Skor & Sampah Terlewat");
        GUI.skin.label.fontSize = 25;
        GUI.skin.label.normal.textColor = Color.white;
        GUI.Label(new Rect(20,20,700,40), "Skor: " + score + "  Terlewat: " + missed);
        GUI.Label(new Rect(20,60,1000,40), pesan);    

        //tambahkan gameover jika missed =5 dan tombol restart
        if (missed >= 5)
        {   
            Time.timeScale = 0;
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Game Over");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 30), "Restart"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }

}
