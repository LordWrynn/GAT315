using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	[SerializeField] Body bodyPrefab;
	[SerializeField] FloatData speed;

	bool action = false;
	bool pressed = false;
	//float timer = 0;

	public void OnPointerDown(PointerEventData eventData) {
		action = true;
		pressed = true;
    }

	public void OnPointerExit(PointerEventData eventData) {

    }

    public void OnPointerUp(PointerEventData eventData) {
//        throw new System.NotImplementedException();
    }

    void Update() {
		if (action && (pressed || Input.GetKey(KeyCode.LeftControl))) {
			pressed = false;
			Vector3 position = Simulator.Instance.GetScreenToWorldPosition(Input.mousePosition);
			Body body = Instantiate(bodyPrefab, position, Quaternion.identity);
			body.shape.size = size.value;
			body.ApplyForce(Random.insideUnitCircle.normalized * speed.value, Body.ForceMode.VELOCITY);
			Simulator.Instance.bodies.Add(body);
        }
	}
}
