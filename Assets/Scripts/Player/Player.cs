using spaceExplorer.DamageSystem;
using spaceExplorer.Health;
using UnityEngine;

namespace spaceExplorer.Player
{
    public class Player : MonoBehaviour, IDamageSource
    {
        public static Player Instance { get; private set; }
        private PlayerMove playerMove;
        private PlayerAttack playerAttack;
        private readonly float damage = 10f;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            playerAttack = GetComponent<PlayerAttack>();
            playerAttack.DamageDealer = GetComponent<DamageDealer>();
            playerMove = GetComponent<PlayerMove>();
            playerMove.PlayerTransform = transform;
        }
        float IDamageSource.GetDamage() => damage;
        
    }
}

