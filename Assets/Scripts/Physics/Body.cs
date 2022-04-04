using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    public enum ForceMode { FORCE, VELOCITY, ACCELERATION }

    public Shape shape;
    public Vector2 position { get => transform.position; set => transform.position = value; }
    public Vector2 velocity { get; set; } = Vector2.zero;
    public Vector2 acceleration { get; set; } = Vector2.zero;
    public Vector2 force { get; set; } = Vector2.zero;
    public float mass => shape.mass;
    public float inverseMass { get => (mass == 0) ? 0 : 1 / mass; }

    public void ApplyForce(Vector2 force, ForceMode fm) {
        switch (fm) {
            case ForceMode.FORCE:
                acceleration += force * inverseMass;
                break;
            case ForceMode.VELOCITY:
                this.force += force;
                break;
            case ForceMode.ACCELERATION:
                acceleration = 
        }
        this.force += force;
    }
    public void Step(float dt) {
        acceleration = Simulator.Instance.gravity + (force * inverseMass);
    }
        
}
