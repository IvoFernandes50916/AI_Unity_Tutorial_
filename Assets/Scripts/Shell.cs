using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float speed = 0f;
    float mass = 10;
    float force = 100;
    float acceleration;
    float drag = 0.2f;
    float gravity = -9.8f;
    float gAcce;
    float ySpeed = 0f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1;
        gAcce = gravity / mass;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        ySpeed += gAcce * Time.deltaTime;
        this.transform.Translate(0, ySpeed, Time.deltaTime * speed);
        
    }
}
