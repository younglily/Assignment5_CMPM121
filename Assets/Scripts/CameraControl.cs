using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject playerCharacter;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - playerCharacter.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerCharacter.transform.position + distance;
    }
}
