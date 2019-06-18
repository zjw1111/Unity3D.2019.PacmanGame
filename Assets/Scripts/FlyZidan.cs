using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyZidan : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.up, Space.World);
        Vector2 movement = new Vector2(transform.rotation.z / 2, transform.rotation.w / 2);
        rb2D.AddForce(movement * speed);
    }

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //    Debug.Log("Tag: " + other.gameObject.tag);
    //    if (other.gameObject.tag != "Qiang") Destroy(rb2D.gameObject);
    //}
}
