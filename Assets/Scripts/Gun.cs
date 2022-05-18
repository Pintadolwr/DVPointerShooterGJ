using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private GameObject[] maxRotations; 
    [SerializeField]
    private int current = 0;
    [SerializeField]
    private float speedRotation;

    [SerializeField]
    private GameObject bulletPrefab;

    // Update is called once per frame
    void Update() { 
        Vector3 targetDirection = maxRotations[current].transform.position - transform.position;
        float singleStep = speedRotation * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        if (Physics.Raycast(transform.position, newDirection * 100))
        {
            current++;
            if (current == 2)
            {
                current -= 2;
            }
        }
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(bulletPrefab, new Vector3(-16.226F, 5.06f,4.66f), transform.rotation);
        }
    }
}
