using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // world
        transform.position += Vector3.forward * 5 * Time.deltaTime;
        // local
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        // world
        transform.Translate(Vector3.forward * 5 * Time.deltaTime, Space.World);

        transform.rotation = Quaternion.identity;
        // euler 2 quaternion
        transform.rotation = Quaternion.Euler(new Vector3(30, 60, 120));
        //quaternion 2 euler
        // transform.rotation.eulerAngles

        var newRot = transform.rotation.eulerAngles + Vector3.up * Time.deltaTime;
        transform.rotation = Quaternion.Euler(newRot);

        transform.Rotate(Vector3.up * 5  * Time.deltaTime);
    }
}
