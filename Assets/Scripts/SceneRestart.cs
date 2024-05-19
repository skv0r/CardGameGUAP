using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    // Метод для перезапуска текущей сцены
    public void RestartScene()
    {
        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Перезагружаем текущую сцену по ее индексу
        SceneManager.LoadScene(currentSceneIndex);
    }
}
