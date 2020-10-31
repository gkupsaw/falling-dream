using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace FallingDream.Player {
    public class Health : MonoBehaviour
    {
        public int health = 3;
        public Text healthTxt;

        void Start() {
            healthTxt.text = "Lives: " + health;
        }

        public void TakeDamage() {
            if (health > 0) {
                health--;
                healthTxt.text = "Lives: " + health;
            }
            if (health == 0) {
                Debug.Log("Gameover");
            }
        }
    }
}
