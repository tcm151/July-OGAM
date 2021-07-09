using UnityEngine;
using UnityEngine.UI;

namespace OGAM.Environment
{
    public class QuitGameButton : MonoBehaviour
    {
        Button button;
        private void Awake() => button = GetComponent<Button>();

        private void OnMouseUpAsButton() => SceneSwitcher.ReloadScene();
    }
}
