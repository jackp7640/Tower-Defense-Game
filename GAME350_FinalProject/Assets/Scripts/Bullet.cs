using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 2f;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        // Referenced from https://www.youtube.com/watch?v=-thhMXmTM7Q
        Vector3 moveDirection = (target.position - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) < 1f)
        {
            // destroy enemy
            Destroy(target.gameObject);
            // destroy the bullet itself
            Destroy(gameObject);
        }
    }

}
