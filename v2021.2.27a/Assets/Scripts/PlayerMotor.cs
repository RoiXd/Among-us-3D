
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour 
{
	[SerializeField]
	private Camera cam;
	private Vector3 velocity;
	private Rigidbody rb;
	private Vector3 rotation;
	private Vector3 cameraRotation;

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

	public void rotateCamera(Vector3 _cameraRotation) 
	{
		cameraRotation = _cameraRotation;
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
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
		cam.transform.Rotate (-cameraRotation);
	}
}
