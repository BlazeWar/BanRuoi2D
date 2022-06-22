using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public float timeToDestroy;

    Rigidbody2D m_rb;

    GameController m_gc;

    AudioSource aus;

    public AudioClip hitSound;

    public GameObject hitVFX;

    

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, timeToDestroy);
        
    }

    // Update is called once per frame
    void Update()
    {
        //thay doi position trong thanh phan transform
        //dung phuong thuc AddForce cua thanh phan rigidbody2d
        //Vector2.up = (0,1)
        m_rb.velocity = Vector2.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            //Tang diem so cua nguoi choi o day
            m_gc.ScoreIncrement();

            if(aus && hitSound)
            {
                aus.PlayOneShot(hitSound);
            }

            if (hitVFX)
            {
                Instantiate(hitVFX, col.transform.position, Quaternion.identity);

                
            }

            

            Destroy(gameObject);

            Destroy(col.gameObject);

            Debug.Log("Vien dan da va cham enemy");
        }else if (CompareTag("SceneTopLimit"))
        {
            Destroy(gameObject);
        }
    }
}
