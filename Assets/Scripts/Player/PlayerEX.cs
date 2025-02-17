using UnityEngine;

public class PlayerEx : MonoBehaviour
{
    [SerializeField] private AudioClip dieSFX;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position);
            Destroy(gm, 2f);
          
            Destroy(this.gameObject);
        }
    }
}
    // Game ovel


