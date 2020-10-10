using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float m_radius = 2.5f;
    public int m_destroy_time = 4;
    public int m_instantiate_delay = 100;
    public GameObject[] m_possible_objects;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % m_instantiate_delay == 0) {
            GameObject obj = m_possible_objects[Random.Range(0, m_possible_objects.Length)];
            GameObject objectInstance = Instantiate(
                obj,
                new Vector3(Random.Range(-m_radius, m_radius), 0, Random.Range(-m_radius, m_radius)),
                Quaternion.identity
            );
            Destroy(objectInstance, m_destroy_time);
        }
    }
}
