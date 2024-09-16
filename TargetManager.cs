using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets; // Assign in the Inspector or find at runtime
    private int totalTargets;
    private int targetsHit;

    void Start()
    {
        totalTargets = targets.Length;
        targetsHit = 0;
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
        // Load the next level by increasing the current level index
        // Ensure the next level index logic aligns with your level setup
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0; // Loop back to the first level or handle game completion
        }

        SceneManager.LoadScene(nextLevelIndex);
    }
}
