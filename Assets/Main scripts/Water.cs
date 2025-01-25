using UnityEngine;

public class Water : MonoBehaviour
{
    private Transform WaterPos;
    private bool onPos = false;

    // Start is called before the first frame update
    void Start()
    {
        WaterPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            positionCheck();

        if (bubble.Move)
        {
            if(!onPos)
            {
                WaterPos.position += new Vector3(0, .5f, 0) * Time.deltaTime;
            }
        }
    }
    private void positionCheck()
    {
        if (WaterPos.position.y >= -3)
        {
            onPos = true;
        }
        else
        {
            onPos = false;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Clone") || collision.CompareTag("Super"))
        {
            Destroy(collision.gameObject);
        }

    }
}
