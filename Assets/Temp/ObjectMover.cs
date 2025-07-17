using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float dst = 10;
    [SerializeField] private float speed = 1f;
    private bool side;
    void Update()
    {
        transform.position += new Vector3((side ? 1 : -1) * speed * Time.deltaTime, 0, 0);

        if (side && transform.position.x >= dst)
        {
            side = !side;
        }
        
        if (!side && transform.position.x <= -dst)
        {
            side = !side;
        }
    }
    
}
