using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For displaying the timer

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets; // Assign in the Inspector or find at runtime
    public Text timerText; // Assign this in the Inspector

    private int totalTargets;
    private int targetsHit;
    private float timer; // Timer in seconds

    void Start()
    {
        totalTargets = targets.Length;
        targetsHit = 0;
        timer = 0f;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (true)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
            yield return null; // Wait until the next frame
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int milliseconds = Mathf.FloorToInt((timer - Mathf.Floor(timer)) * 1000);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void TargetHit()
    {
        targetsHit++;
        if (targetsHit >= totalTargets)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0; // Loop back to the first level or handle game completion
        }

        SceneManager.LoadScene(nextLevelIndex);
    }
}

