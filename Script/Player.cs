using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField]
    private float movmentspeed = 7f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(pos.x < 0)
            {
                Debug.Log(Vector2.left);
                rb.position += Vector2.left * movmentspeed * Time.deltaTime;
            }
            else
            {

                rb.position += Vector2.right * movmentspeed * Time.deltaTime;
            }

            Vector2 clamppos = transform.position;
            clamppos.x = Mathf.Clamp(clamppos.x, -2.3f, 2.3f);
            gameObject.transform.position = clamppos;

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="crate")
        {
            SceneManager.LoadScene(0);
        }
    }
}
