using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    [SerializeField] private bool drawGizmos;
    private Rigidbody2D _rb;
    [SerializeField] private Animator _anim;
    private Transform _point;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _point = pointB.transform;
        _anim.SetInteger("AnimState", 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = _point.position - transform.position;
        if (_point == pointB.transform) {
            _rb.velocity = new Vector2(speed, 0);
        } else {
            _rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, _point.position) < 1f) {
            if (_point == pointB.transform) {
                flip();
                _point = pointA.transform;
            } else {
                flip();
                _point = pointB.transform;
            }
        }
    }

    private void flip() {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos() {
        if (drawGizmos == true) {
            Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
            
        }
    }
}
