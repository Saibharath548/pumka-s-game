using UnityEngine;

public class Water : MonoBehaviour
{
    private Transform WaterPos;
    private bool onPos = false;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        WaterPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            positionCheck();
        position = new Vector3(0, -3, 0);
        if (bubble.Move)
        {
            dobro();
        }
    }

    private void dobro()
    {
        if (!onPos)
        {
            WaterPos.position += new Vector3(0, 0.1f, 0);
        }
    }

    private void positionCheck()
    {
        if (WaterPos.position.y == -3)
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
