
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class Control : MonoBehaviour {
	public float speed;

	public float mouseSensibility;

	private PlayerMotor motor;

	void Start () {
		motor = GetComponent<PlayerMotor> ();
	}

	void Update () {
		//calcul de la vitesse de mouvment de persnage
		float xMov = Input.GetAxisRaw ("Horizontal"); 
		float zMov = Input.GetAxisRaw ("Vertical"); 
	
		Vector3 moveHorizontal = transform.right * xMov;
		Vector3 moveVertical = transform.forward * zMov;

		Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
	
		motor.move (velocity);
		//calcul du rotation de personage
		float yRot = Input.GetAxisRaw ("Mouse X");

		Vector3 rotation = new Vector3 (0, yRot, 0);
		motor.rotate (rotation);
		//calcul du rotation de Camera
		float xRot = Input.GetAxisRaw ("Mouse Y");
		Mathf.Clamp(xRot, -60, 70);
		Vector3 CameraRotation = new Vector3 (xRot, 0, 0) * mouseSensibility;
		motor.rotateCamera (CameraRotation);
	}
}
