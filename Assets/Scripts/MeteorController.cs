using System.Collections;
using UnityEngine;
using System.Collections.Generic;




 public class MeterorController : MonoBehaviour
{
     public float Meterorspeed= 25f ;
void Update()
   {
    transform.Translate(Vector3.up * Meterorspeed * Time.deltaTime);

   }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameObject gm = Instantiate(GameManager.instance.explosion, transform.position, transform.rotation);

            Destroy(gm, 2f);


            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }




}
