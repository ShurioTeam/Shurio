#pragma strict
public var throw_time:float = 10.0f;
public var CHEST_MASS:float = 0.0f;
function Start () {
	this.gameObject.transform.position.z = 0;
	CHEST_MASS = this.gameObject.GetComponent.<Rigidbody2D>().mass;
}

function Update () {
	this.gameObject.transform.position.z = 0;
}


function NowThrowing() {
	var collider:BoxCollider2D = this.gameObject.GetComponentInChildren(BoxCollider2D);
	var material:PhysicsMaterial2D = new PhysicsMaterial2D();
	material.friction = 0.0f;
	material.bounciness = 1.0f;
	collider.sharedMaterial = material;
	var time:float = 0.0f;
	while (time < throw_time) {
		time += Time.deltaTime;
	}
	collider.sharedMaterial = null;
	SetMass();
}

function SetMass() {
	this.gameObject.GetComponent.<Rigidbody2D>().mass = CHEST_MASS;
}