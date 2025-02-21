using spaceExplorer.DamageSystem;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace spaceExplorer.Player
{
    public class Player : MonoBehaviour, IDamageSource
    {
        public static Player Instance { get; private set; }
        private PlayerMove playerMove;
        private PlayerAttack playerAttack;
        private readonly float damage = 10f;
        private PlayerEx playerExplode;
        
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Keep player persistent
            }
            else
            {
                Destroy(gameObject); // Destroy duplicate instances
            }

            playerExplode = GetComponent<PlayerEx>();
            playerAttack = GetComponent<PlayerAttack>();
            playerAttack.DamageDealer = GetComponent<DamageDealer>();
            playerMove = GetComponent<PlayerMove>();
            playerMove.PlayerTransform = transform;

            transform.position = Vector3.zero; // Reset player position
            SceneManager.sceneLoaded += OnSceneLoaded;
            playerExplode.OnDeath += PlayerExplode_OnDeath;
        }
        private void PlayerExplode_OnDeath(object sender, System.EventArgs e)
        {
            playerAttack.DisableAction();
            Destroy(gameObject);
        }
        private void Start()
        {
            CinemachineCameraManager.Instance.SetFollowTarget(transform);
        }
        private void Update()
        {
            if (SceneManager.GetActiveScene().name.Equals("EndMenu"))
            {
                gameObject.SetActive(false);
                return;
            }
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(SceneManager.GetActiveScene().name == "EndMenu")
            {
                Destroy(this.gameObject);
                return;
            }
            CinemachineCameraManager.Instance.SetFollowTarget(transform);
        }
        float IDamageSource.GetDamage() => damage;
        private void OnDestroy()
        {
            if (playerAttack != null)
            {
                playerAttack.DisableAction(); // Ensure input is disabled
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}

