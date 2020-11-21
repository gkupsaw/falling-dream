using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDream.System {
    public class SpawnObjects : MonoBehaviour
    {
        [Header("Spawn Location/Frequency")]
        // public float m_radius = 5f; // radius of area in x that objects can appear in
        public float m_spawnY = 0f;
        public float m_maxY = 10f;
        public int m_objsPerSec = 1;

        [Header("Object Behavior")]
        public float m_speed = 10f;
        public float m_torque = 10f;

        [Header("Related Objects")]
        public GameObject[] m_possibleObjects;
        public GameObject m_player;

        private FallingDream.Player.SimplePlayerMovement _playerScript;
        private float m_radius;


        private float timeSinceSpawn = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            _playerScript = m_player.GetComponent<FallingDream.Player.SimplePlayerMovement>();
            m_radius = _playerScript.MaxDisplacement;
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceSpawn += Time.deltaTime;
            if (timeSinceSpawn >= 1.0 / m_objsPerSec) {
                timeSinceSpawn = timeSinceSpawn % (1.0f / m_objsPerSec);
                GameObject obj = m_possibleObjects[Random.Range(0, m_possibleObjects.Length)];
                GameObject objectInstance = Instantiate(
                    obj,
                    new Vector3(Random.Range(-m_radius, m_radius), m_spawnY, Random.Range(-m_radius, m_radius)), // object position
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
