using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float vMouseSens = 1; 
    public float hMouseSens = 1;
    public bool isMouseReverseH= false;

    public float rotSpeed = 200f;

    public float mx = 0;
    public float my = 0; 

    void Update()
    {
        int hDir = isMouseReverseH ? -1 : 1;
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = hDir * Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, mx, 0);

        /// degree 값이 나중에 수정되어 오류발생 
        ///Vector3 dir = new Vector3(mouse_Y, mouse_X, 0f);
        ///
        ///transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        ///
        ///Vector3 rot = transform.eulerAngles;
        ///rot.x = Mathf.Clamp(rot.x, -90f, 90f);
        ///transform.eulerAngles = rot;

    }
}
