using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public Transform T;
    public Transform T1;
    [SerializeField] private GameObject BubbleBullet;
    [SerializeField] private float BulletSpeed;
    [SerializeField]private float CDistance;
    private bool pR = false;
    private bool shoot = true;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //aiMove();
        //T = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pR)
        {
            aiMove();
        }
    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            pR = true;
        }
    }
 

    private void aiMove()
    {

        direction = MoveT.instance.transform.position - T.position;

        T.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        T.position = T1.position + Quaternion.Euler(0, 0, angle) * new Vector3(CDistance, 0, 0);

        if(shoot)
        StartCoroutine(yeahSo());

    }
    IEnumerator yeahSo()
    {
        shoot = false;
        yield return new WaitForSeconds(1);

        GameObject BB = Instantiate(BubbleBullet, T.position, Quaternion.identity);

        BB.GetComponent<Rigidbody2D>().velocity = direction.normalized * BulletSpeed;

        Destroy(BB, 5);
        shoot = true;
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (pR)
    //    {
    //        if (collision.CompareTag("player"))
    //        {
    //            Vector3 direction = P.position - transform.position;

    //            T.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    //            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //        }
    //    }
    //}
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pR = false;
        }
    }

}
