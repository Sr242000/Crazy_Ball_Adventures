using UnityEngine;

public class p : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(1 * Time.deltaTime, 0, 0);

        }



        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position - new Vector3(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(0, 0, 1 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position - new Vector3(0, 0, 1 * Time.deltaTime);
        }
    }
}
