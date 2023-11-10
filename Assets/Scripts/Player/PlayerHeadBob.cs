using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadBob : MonoBehaviour
{
    [SerializeField, Range(0.001f, 0.01f)] private float amount = 0.02f;
    [SerializeField, Range(1f, 30f)] private float frequency = 10f;
    [SerializeField, Range(10f, 100f)] private float smooth = 10f;
    // Update is called once per frame
    void Update()
    {
        CheckForHeadBobTrigger();
    }

    public Vector3 HandleHeadBobbing()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * frequency) * amount * 1.4f, smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * frequency / 2f) * amount * 1.6f, smooth * Time.deltaTime);
        transform.localPosition += pos;
        return pos;
    }

    private void CheckForHeadBobTrigger()
    {
        float input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;

        if (input > 0)
        {
            HandleHeadBobbing();
        }
    }
}