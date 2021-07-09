using UnityEngine.SceneManagement;

namespace OGAM.Environment
{
    public static class SceneSwitcher
    {
        public static void LoadScene(int toThis) => SceneManager.LoadScene(toThis);

        public static void QuitGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public static void ReloadScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
