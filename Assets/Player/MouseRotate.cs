using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    Vector2 mouseP;
    Vector2 objectP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*objectP.x = this.transform.position.x;
        objectP.y = this.transform.position.y;

        mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseP.x = mouseP.x - objectP.x;
        mouseP.y = mouseP.y - objectP.y;
       
        float angle = (180 / Mathf.PI) * Mathf.Atan2(mouseP.y, mouseP.x);
        this.transform.rotation = Quaternion.Euler(0, 0, angle); 
        Vector3 point = GetComponentInParent<Transform>().position;
        Vector3 axis = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GetComponentInParent<Transform>().position;
        Debug.DrawLine(GetComponentInParent<Transform>().position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.RotateAround(point, axis, Time.deltaTime * 10);*/
      
    }
}
