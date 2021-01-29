
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour 
{
	private Vector3 velocity;
	private Rigidbody rb;
	private Vector3 rotation;
	void Start() 
	{
		rb = GetComponent<Rigidbody> ();
	}

	public void move(Vector3 _velocity) 
	{
		velocity = _velocity;
	}
	public void rotate(Vector3 _rotation) 
	{
		rotation = _rotation;
	}

	private void FixedUpdate()
	{
		PerformMovement();
		PerformRotation ();
	}

	private void PerformMovement() 
	{
		if(velocity != Vector3.zero) 
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	private void PerformRotation ()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));
	}
}
