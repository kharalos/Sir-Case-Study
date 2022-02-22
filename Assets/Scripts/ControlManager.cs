using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    [SerializeField] private float moveSpeed = 1, rotSpeed = 1;
    private float X , Y;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 direction){
        X = direction.x;
        Y = direction.y;
    }

    void FixedUpdate()
    {
        m_Rigidbody.velocity = Y * transform.forward * moveSpeed;
        transform.Rotate(Vector3.up, X * rotSpeed);
    }
}
