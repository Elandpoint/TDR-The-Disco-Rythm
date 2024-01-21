using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    bool active = false;
    GameObject note;


    void Update()
    {
        if (Input.GetKeyDown(key) && active) {
        Destroy(note);
        }
    }
    void OnTriggerEnter3D(Collider col)
    {
        active = true;
        if (col.gameObject.tag == "Note")
            note = col.gameObject;
    }
    void OnTriggerExit3D(Collider col)
    {
        active = false;
    }
}
