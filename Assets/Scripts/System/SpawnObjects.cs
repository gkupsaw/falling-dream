using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDream.System {
    public class SpawnObjects : MonoBehaviour
    {
        public float m_radius = 5f; // radius of area in x that objects can appear in
        public float m_spawnY = 0f;
        public float m_maxY = 10f;
        public int m_objsPerSec = 1; // ms
        public float m_speed = 10f;
        public float m_torque = 10f;
        public GameObject[] m_possibleObjects;
        public GameObject m_player;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.frameCount % (m_objsPerSec * 70) == 0) {
                Vector3 playerOrigin = m_player.transform.position;
                playerOrigin.y = 0;
                GameObject obj = m_possibleObjects[Random.Range(0, m_possibleObjects.Length)];
                GameObject objectInstance = Instantiate(
                    obj,
                    playerOrigin + new Vector3(Random.Range(-m_radius, m_radius), m_spawnY, Random.Range(-m_radius, m_radius)),
                    Quaternion.identity
                );

                Rigidbody rb = objectInstance.GetComponent<Rigidbody>();
                float timeAlive = m_maxY / m_speed;
                float thrust = rb.mass * m_speed;
                rb.AddForce(objectInstance.transform.up * thrust, ForceMode.Impulse);
                rb.AddTorque(new Vector3(Random.Range(0, m_torque), Random.Range(0, m_torque), Random.Range(0, m_torque)));

                // Destroy(objectInstance, timeAlive);
            }
        }
    }
}
