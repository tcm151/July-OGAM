using OGAM.Player;
using UnityEngine;
using OGAM.Tools;
using OGAM.SceneManagement;

namespace OGAM.Environment
{
    public class DeathZone : MonoBehaviour
    {
        public LayerMask playerMask;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!playerMask.Contains(collider.gameObject.layer)) return;

            //Debug.Log("<color=red>PLAYER DEATH!</color>");
            //collider.transform.position = new Vector3(0, 1, 0);
            // SceneSwitcher.ReloadScene();

            var checkpointManager = collider.GetComponent<CheckpointManager>();
            if (checkpointManager is null) return;
            
            checkpointManager.ReturnToCurrentCheckpoint();
        }
        
    }
}
