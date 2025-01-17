using UnityEngine;

namespace spaceExplorer.player
{
    public class Player : MonoBehaviour
    {
        private PlayerMove playerMove;
        private void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            playerMove.playerTransform = transform;
        }
    }
}

