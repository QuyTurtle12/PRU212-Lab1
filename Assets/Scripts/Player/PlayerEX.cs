using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEx : MonoBehaviour
{
    [SerializeField] private AudioClip dieSFX;

    public event EventHandler OnDeath;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position);
            Destroy(gm, 2f);

            Destroy(this.gameObject);

            OnDeath?.Invoke(this.gameObject, EventArgs.Empty);
        }
    }


}
// Game ovel


