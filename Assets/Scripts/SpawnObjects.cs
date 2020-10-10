using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float m_radius = 2.5f; // radius of area in x that objects can appear in
    public int m_destroy_time = 4; // ms
    public int m_objs_per_sec = 1; // ms
    public float m_speed = 80f;
    public GameObject[] m_possible_objects;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % (m_objs_per_sec * 100) == 0) {
            GameObject obj = m_possible_objects[Random.Range(0, m_possible_objects.Length)];
            GameObject objectInstance = Instantiate(
                obj,
                new Vector3(Random.Range(-m_radius, m_radius), 0, Random.Range(-m_radius, m_radius)),
                Quaternion.identity
            );
            Rigidbody rBody = objectInstance.GetComponent<Rigidbody>();
            rBody.AddForce(objectInstance.transform.up * m_speed);
            Destroy(objectInstance, m_destroy_time);
        }
    }
}
