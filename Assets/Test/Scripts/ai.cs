using UnityEngine;

public class ai : MonoBehaviour
{
    public Transform P;
    public Transform T;
    private bool pR = false;
    // Start is called before the first frame update
    void Start()
    {
        //T = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pR = true;
        if (pR = true)
        {
            if (collision.CompareTag("player"))
            {
                aiMove();
            }
        }
    }

    private void aiMove()
    {
        Vector3 direction = P.position - transform.TransformPoint(T.position);
        T.localRotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        pR=false;
        if(pR = true)
        {
            if(collision.CompareTag("player"))
            {
                aiMove();
            }
        }
    }

}
