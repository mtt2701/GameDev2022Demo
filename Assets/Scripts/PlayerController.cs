using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

    Rigidbody2D rb2d;

    float hor;
    float vert;

    float speed;

    Vector2 dir;
    Vector2 lookDir;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float castLength;
    
    bool onGround;

    [SerializeField]
    LayerMask groundLayer;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 8f;
        jumpForce = 10f;
        castLength = 1.1f;
        onGround = false;
    }

    void Update() {

        onGround = Physics2D.Raycast(transform.position, Vector2.down, castLength, groundLayer);
        Debug.Log(onGround);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = 3f;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 8f;

        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        if (vert > 0 && onGround) {
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        //if (!Interactable.status)
        //    if (dir.magnitude != 0)
        //        lookDir = dir.normalized;

        /*if (Input.GetKeyDown(KeyCode.Z)) {
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position, lookDir, globals.raycastdist, LayerMask.GetMask("Interactable"));
            if (hit.collider != null) {
                hit.collider.gameObject.SendMessage("Interacted");
            }
        }*/
    }

    void FixedUpdate() {
        rb2d.velocity = new Vector2(hor * speed, rb2d.velocity.y);
    }
}