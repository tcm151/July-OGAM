using UnityEngine;
using UnityEngine.SceneManagement;

namespace OGAM.Environment
{
    public class SceneSwitch : MonoBehaviour
    {
        public void SwitchScenes(int toThis)
        => SceneManager.LoadScene(toThis); //For other scripts to access

        public void RestartScene()
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
    }
}
