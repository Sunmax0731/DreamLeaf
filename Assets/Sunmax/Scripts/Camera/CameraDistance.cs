using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
public class CameraDistance : MonoBehaviour
{
    [SerializeField] private float Distance;
    [SerializeField] private float Scale = 0.1f;
    [SerializeField] private Vector2 LimitDistance = new Vector2(-3, 10);
    [SerializeField] private CinemachineCameraOffset _cinemachineOffset;
    // Start is called before the first frame update
    void Start()
    {
        _cinemachineOffset = GetComponent<CinemachineCameraOffset>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance -= Input.mouseScrollDelta.y * Scale;
        Distance = Mathf.Clamp(Distance, LimitDistance.x, LimitDistance.y);

        _cinemachineOffset.m_Offset = new Vector3(0f, Mathf.Sqrt(Distance) / 2, Distance);
    }
}
