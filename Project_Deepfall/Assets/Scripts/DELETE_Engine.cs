using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DELETE_Engine : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float turnSpeed;

    private InputSystemKeyboard inputSystem;

    void Awake()
    {
        inputSystem = GetComponent<InputSystemKeyboard>();
    }

    void Update()
    {
        transform.position += inputSystem.ver * transform.up * speed * Time.deltaTime;

        transform.Rotate(new Vector3(0, 0, -1) * inputSystem.hor * turnSpeed * Time.deltaTime);
    }
}
