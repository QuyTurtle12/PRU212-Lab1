using UnityEngine;

public class PlayerEx : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);

            Destroy(gm, 2f);
          
            Destroy(this.gameObject);
        }
    }
}
    // Game ovel


