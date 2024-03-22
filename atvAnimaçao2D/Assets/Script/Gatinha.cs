using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gatinha : MonoBehaviour
{
    public float speed = 10;
    public int forcaPulo = 8;
    public bool noChao;
    private Rigidbody2D rig;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = Vector2.right * speed;
            anim.SetBool("EstaCorrendo", true);
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (Input.GetKey((KeyCode.A)))
        {
            rig.velocity = Vector2.left * speed;
            anim.SetBool("EstaCorrendo", true);
            transform.eulerAngles = new Vector2(0f, 180f);
        } 
        else
        {
            anim.SetBool("EstaCorrendo", false);
        }

        if (Input.GetKey(KeyCode.Space) && noChao)
        {
            rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            anim.SetBool("EstaPulando", true);
            transform.eulerAngles = new Vector2(0f, 180f);
            noChao = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!noChao && collision.gameObject.tag == "Chao")
        {
            anim.SetBool("EstaPulando", false);
            anim.SetBool("EstaCorrendo", false);
            noChao = true;
        }
    }
}
