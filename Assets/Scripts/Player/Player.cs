using spaceExplorer.DamageSystem;
using spaceExplorer.Health;
using UnityEngine;

namespace spaceExplorer.Player
{
    public class Player : MonoBehaviour, IDamageSource
    {
        public Player Instance { get; private set; }
        private PlayerMove playerMove;
        private PlayerAttack playerAttack;
        private float damage = 10f;
        private float maxHealth = 100f;
        private HealthSystem healthSystem;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }

            playerAttack = GetComponent<PlayerAttack>();
            playerAttack.damageDealer = GetComponent<DamageDealer>();
            playerMove = GetComponent<PlayerMove>();
            playerMove.playerTransform = transform;
            healthSystem = GetComponent<HealthSystem>();
            healthSystem.Setup(maxHealth);
        }
        float IDamageSource.GetDamage() => damage;
        
    }
}

