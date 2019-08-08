using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickermovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    Vector3 movement;
    public Vector3 MoveVector {set;get;}
    private Rigidbody thisrigidbody;
    public vertialJoystick jstick;
    // Start is called before the first frame update
    void Awake()
    {
        thisrigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = jstick.Horizontal();
        float v = jstick.vertical();
        Move(h,v);
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        thisrigidbody.MovePosition(transform.position + movement);
    }

}
