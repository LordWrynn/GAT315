using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyCreator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	[SerializeField] BodyCreator bodyPrefab;

	bool action = false;
	bool pressed = false;
	float timer = 0;

	public void OnPointerDown(PointerEventData eventData) {
		action = true;
		pressed = true;
    }

	public void OnPointerExit(PointerEventData eventData) {

    }

    public void OnPointerUp(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }

    void Update() {
		if (action) {
			Vector3 position = Simulator.Instance.GetScreenToWorldPosition(Input.mousePosition);
			Body body = Instantiate(bodyPrefab, position, Quaternion.identity);
			Simulator.Instance.bodies.Add(body);
			body.ApplyForce(Random.insideUnitCircle.normalized);
        }
	}
}
