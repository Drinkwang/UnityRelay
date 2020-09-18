using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform tf;
    Vector2 position;
    void Start(){
    	position = tf.position;
    }
    void Update(){
    	Vector2 toward = FUNCTION.GetMousePosition() - position;
    	if(toward.magnitude > 2)toward = toward.normalized * 2;
    	tf.localPosition = toward * 0.04f;
    }
}
