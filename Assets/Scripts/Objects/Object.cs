using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDream.Object {
    public class Object : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collision) {
            collision.gameObject.GetComponent<FallingDream.Player.PlayerHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
