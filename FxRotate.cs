using UnityEngine;
using System.Collections;

public class FxRotate : MonoBehaviour {


	void Update () {

        transform.Rotate(0, 50 * Time.deltaTime, 0);
	}
}
