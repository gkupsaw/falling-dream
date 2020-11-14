using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDream.Object {
    public class ObjectMovement : MonoBehaviour
    {

        public AudioClip hitSound;

        private void OnTriggerEnter(Collider collision) {
            GameObject obj = collision.gameObject;
            switch (obj.tag)
            {
                case "ObjectDestructor":
                    GameObject.FindWithTag("System").GetComponent<FallingDream.System.ScoreSystem>().IncrementScore();
                    Destroy(gameObject);
                    break;
                case "Player":
                    obj.GetComponent<FallingDream.Player.PlayerHealth>().TakeDamage();
                    obj.GetComponent<FallingDream.Player.PlayObjectHit>().Play(hitSound);
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
