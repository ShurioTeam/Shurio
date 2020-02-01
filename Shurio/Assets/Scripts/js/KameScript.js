#pragma strict
			
private var anime:Animator;
private var direction:int;
private var kame:GameObject;
private var kora_time:float;
public var high_power:int = 6;
public var low_power:int = 4;
public var KAME_MASS:float;

public var wakeup_time:float = 10.0f;
public var throw_time:float = 10.0f;
function Start () {
	kame = this.gameObject;
	kame.transform.position.z = 0;
	anime = kame.GetComponentInChildren(Animator);
	anime.SetBool("InKora",false);
	kora_time = 0.0f;

	var dir:float = Random.Range(1.0F, 2.0F);
	if (dir <= 1.5) {
		direction = 1;
		kame.transform.Rotate(0, 180, 0);
	} else {
		direction = -1;
	}
	KAME_MASS = kame.GetComponent.<Rigidbody2D>().mass;
}

function Update () {
	kame.transform.position.z = 0;
	var power:int = Random.Range(low_power, high_power);
//	var rkame:Quaternion = kame.transform.rotation;
	var vkame:Vector3 = kame.transform.localEulerAngles;
	var inkora:boolean = anime.GetBool("InKora");
	if (!inkora && (vkame.z >= -10 && vkame.z <= 10)) {
		kame.GetComponent.<Rigidbody2D>().AddForce(Vector2(direction,0)*power);
		//anime.SetBool("InKora", false);
		kora_time = 0.0f;
	} else {
		anime.SetBool("InKora",true);
	}


	if (inkora) {
		if (kora_time > wakeup_time) {
			if (vkame.z >= -10 && vkame.z <= 10) {
				anime.SetBool("InKora", false);
			}
		}
		kora_time += 1 * Time.deltaTime;
	}
}

function OnTriggerEnter2D(collider:Collider2D) {
	direction *= -1;
	kame.transform.Rotate(0, 180,0);

	if (collider.tag == "Player") {
		var face:Vector3 = collider.gameObject.transform.position;
		var posi:Vector3 = kame.transform.position;
		if ((face - posi).y > 0 || (face - posi).y < 0) {
			anime.SetBool("InKora", true);
		}
	}
}

function NowThrowing() {
	var collider:BoxCollider2D = kame.GetComponentInChildren(BoxCollider2D);
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
	kame.GetComponent.<Rigidbody2D>().mass = KAME_MASS;
}