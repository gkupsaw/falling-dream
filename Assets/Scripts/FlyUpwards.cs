using UnityEngine;

public class FlyUpwards : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 80f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(transform.up * m_Thrust);
    }

    void FixedUpdate()
    {
        // accelerate
        // m_Rigidbody.AddForce(transform.up * m_Thrust);
    }
}
