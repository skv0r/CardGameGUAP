using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadEasyLevel()
    {
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("Difficulty", 1); // 1 - Easy
    }

    public void LoadMediumLevel()
    {
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("Difficulty", 2); // 2 - Medium
    }

    public void LoadHardLevel()
    {
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("Difficulty", 3); // 3 - Hard
    }
}
