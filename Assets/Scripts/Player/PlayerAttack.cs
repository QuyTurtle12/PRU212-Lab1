using spaceExplorer.DamageSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace spaceExplorer.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private InputSystem_Actions action;
        private readonly float laserRange = 100f;
        private LayerMask targetLayer;
        public DamageDealer DamageDealer {  get; set; }

        private void Start()
        {
            
            targetLayer = LayerMask.GetMask("Vulnerable");
            action = new InputSystem_Actions();
            action.Enable();

            action.Player.Attack.performed += OnShootPerformed;
        }
        private void OnShootPerformed(InputAction.CallbackContext context)
        {
            ShootLaser();
        }
        private void ShootLaser()
        {
            // Create a ray starting at the object's position and pointing forward
            Ray ray = new Ray(transform.position, transform.up);
            // Draw a red line from the object's position to the hit point
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * laserRange, Color.red, 1f);
            // Cast a ray in the forward direction
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, laserRange, targetLayer);
            // Check if the ray hits something
            if (hit)
            {
                Vulnerable target = hit.collider.GetComponent<Vulnerable>();
                DamageDealer.DealDamage(target);
                Debug.Log($"Hit {hit.collider.name} at {hit.point}");
            }
            else
            {
                Debug.Log("No hit");
            }
        }        
    }
}

