using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeZidan : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float FasheZidanDeltaTime;
    private float time = 0;
    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time > FasheZidanDeltaTime)
        {
            time = 0;
            Destroy(ball);
            ball = GameObject.Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        else time += Time.deltaTime;
    }
}
