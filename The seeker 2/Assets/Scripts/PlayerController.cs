using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 6f;
    public Transform rt;
    public float smoothtime =  0.1f;
    float current;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float bouflfel = Mathf.Atan2(direction.x ,direction.z)*Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, bouflfel, ref current, smoothtime);
            rt.rotation = Quaternion.Euler(0, angle, 0);
            characterController.Move(direction*speed*Time.deltaTime);
        }
    }
}
