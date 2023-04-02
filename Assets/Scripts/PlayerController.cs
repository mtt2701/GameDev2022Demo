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

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 8f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed = 3f;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 8f;

        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        dir = new Vector2(hor, vert);
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
        Vector2 pos = rb2d.position;
        //if (!Interactable.status) {
            pos.x += hor * speed * Time.deltaTime;
            pos.y += vert * speed * Time.deltaTime;
        //}
        rb2d.MovePosition(pos);
    }
}