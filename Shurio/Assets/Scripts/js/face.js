#pragma strict

public var jumpPower:int = 10;
public var power:int = 10;
public var throwPower:float = 1.0f;
public var throwMass:float = 10.0f;
public var face:GameObject;
public var attack:int = 1000;
public var fireflow:GameObject;
public var lightflow:GameObject;
public var greenflow:GameObject;
private var jumping:boolean = false;
private var anime:Animator;
private var anime_kame:Animator;
private var rotateFlg:boolean;
private var timer:float;
public var nTimer:int = 5;
public var GROUND_MASS = 1.0;
public var chest:GameObject;
public var kame:GameObject;
private static var hand_flag:boolean = false;
private static var hand_chest:GameObject;
private static var hand_kame:GameObject;
private var inkora:boolean = false;
public var walk_divide:float = 100.0f;
public var exec_time:float = 10.0f;
private var stay_time:float = 0.0f;
public var chest002:GameObject;
public var chest007:GameObject;
public var chest010:GameObject;
public var chest030:GameObject;
public var chest050:GameObject;
public var chest100:GameObject;
private var chest_002g:float;
private var chest_007g:float;
private var chest_010g:float;
private var chest_030g:float;
private var chest_050g:float;
private var chest_100g:float;
private var kame_g:float;
private var fire_time:float;
private var isGrounded:boolean = false;
private var isWater:boolean = false;
private var isSky:boolean = false;
private var fireEnabled:boolean = false;
private var lightEnabled:boolean = false;
private var greenEnabled:boolean = false;
private var muki:Quaternion;
function Start () {
	anime = face.GetComponentInChildren(Animator);
	GROUND_MASS = face.GetComponent.<Rigidbody2D>().mass;
	if (walk_divide == 0) {
		walk_divide = 100.0f;
	}
	chest_002g = chest002.GetComponent.<Rigidbody2D>().mass;
	chest_007g = chest007.GetComponent.<Rigidbody2D>().mass;
	chest_010g = chest010.GetComponent.<Rigidbody2D>().mass;
	chest_030g = chest030.GetComponent.<Rigidbody2D>().mass;
	chest_050g = chest050.GetComponent.<Rigidbody2D>().mass;
	chest_100g = chest100.GetComponent.<Rigidbody2D>().mass;

	kame_g = kame.GetComponent.<Rigidbody2D>().mass;

	fire_time = 5.0f;
	rotateFlg = false;
}

function FixedUpdate () {
	if (Input.GetAxis("Fire2") > 0) {
		Debug.Log("Fire2 Push");
	}
	if (isWater && !isGrounded) {
		return ;
	}

	if (!isWater) {
		isGrounded = true;
		face.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
		anime.SetBool("Swim", false);
	}

	var InputX:float = Input.GetAxis("Horizontal");

	//var InputY:float = Input.GetAxis("Vertical");
	var InputY:float = Input.GetAxis("Jump");
	var inputDirection:Vector2 = new Vector2(InputX, InputY);
	var posi:Vector3 = face.transform.position;

	muki = face.transform.rotation;
	if (muki.y < -0.0) {
		rotateFlg = true;
		anime.SetBool("Rotate", true);
	} else {
		rotateFlg = false;
		anime.SetBool("Rotate", false);
	}

	if (!isWater && InputX > 0) {
		face.GetComponent.<Rigidbody2D>().AddForce(Vector2(1,0)*InputX*power);
		face.transform.position += Vector3(1,0,0)*InputX/walk_divide;
		if (rotateFlg) {
			face.transform.Rotate(0, 180, 0);
			if (hand_flag) {
				face.transform.position += Vector3(-0.5,0,0);
			} else {
				face.transform.position += Vector3(-0.2,0,0);
			}
		}
	}

	if (!isWater && InputX < 0) {
		face.GetComponent.<Rigidbody2D>().AddForce(Vector2(1,0)*InputX*power);
		face.transform.position += Vector3(1,0,0)*InputX/walk_divide;
		if (!rotateFlg) {
			face.transform.Rotate(0, 180, 0);
			if (hand_flag) {
				face.transform.position += Vector3(0.5,0,0);
			} else {
				face.transform.position += Vector3(0.2,0,0);
			}
		}
	}

	if (inputDirection.magnitude > 0.1) {
		anime.SetFloat("WorkSpeed",2);
	} else {
		anime.SetFloat("WorkSpeed", 0);
	}

	if (!isWater && InputY > 0 && !jumping) {
		face.GetComponent.<Rigidbody2D>().AddForce(Vector2(0, 1)*jumpPower);
		face.transform.position += Vector3(0,0.5,0);
		jumping = true;
		isGrounded = false;
	}

	if (isGrounded && InputY > 0) {
		anime.SetBool("Jump", true);
	} else {
		anime.SetBool("Jump",false);
	}

	if (Input.GetAxis("Enter") > 0) {
		if (fireflow != null && fireEnabled) {
			if (fire_time > 0.5f) {
				fire_time = 0.0f;
				var _fireflow:GameObject = GameObject.Instantiate(fireflow, this.transform.position, Quaternion.identity);
				_fireflow.SetActive(true);
				_fireflow.GetComponent.<Rigidbody2D>().AddTorque(90);

				if (rotateFlg) {
					_fireflow.GetComponent.<Rigidbody2D>().AddForce(Vector2(-1000, 0));
				} else {
					_fireflow.GetComponent.<Rigidbody2D>().AddForce(Vector2(1000, 0));
				}

				Destroy(_fireflow, 5.0f);
			}
		} else if (lightflow != null && lightEnabled) {
			if (fire_time > 0.2f) {
				fire_time = 0.0f;
				var margin:Vector3 = new Vector3(0.5, 0, 0);
				if (rotateFlg) {
					margin *= -1;
				}
				var _lightflow:GameObject = GameObject.Instantiate(lightflow, this.transform.position + margin, Quaternion.identity);
				_lightflow.SetActive(true);
				_lightflow.GetComponent.<Rigidbody2D>().AddTorque(90);

				if (rotateFlg) {
					_lightflow.GetComponent.<Rigidbody2D>().AddForce(Vector2(-60, 30));
				} else {
					_lightflow.GetComponent.<Rigidbody2D>().AddForce(Vector2(60, 30));
				}

				Destroy(_lightflow, 10.0f);
			}
		} else if (greenflow != null && greenEnabled) {
			if (fire_time > 0.2f) {
				fire_time = 0.0f;
				margin = new Vector3(1.5, 0, 0);
				if (rotateFlg) {
					margin *= -1;
				}
				var _greenflow:GameObject = GameObject.Instantiate(greenflow, this.transform.position + margin, Quaternion.identity);
				_greenflow.SetActive(true);

				if (rotateFlg) {
					_greenflow.GetComponent.<Rigidbody2D>().AddForce(Vector2(-20, 3));
				} else {
					_greenflow.GetComponent.<Rigidbody2D>().AddTorque(180);
					_greenflow.GetComponent.<Rigidbody2D>().AddForce(Vector2(20, 3));
				}

				Destroy(_greenflow, 10.0f);
			}
		}

	}

	fire_time += Time.deltaTime * 1.0f;

	timer += Time.deltaTime;
	if (timer > nTimer * Time.deltaTime) {
		anime.SetBool("Hit", false);
	}
}

function OnCollisionEnter2D(collider:Collision2D) {
	if (jumping) {
		jumping = false;
	}
}

function OnTriggerEnter2D(collider:Collider2D) {
	if (collider.tag == "Fire" || collider.tag == "Enemy") {
		var fire:Vector3 = collider.transform.position;
		var posi:Vector3 = face.transform.position;
		var direction:Vector3 = fire - posi;
		if (collider.tag == "Fire" || direction.y >= 0) {
			anime.SetBool("Hit",true);
			timer = 0.0f;
			face.GetComponent.<Rigidbody2D>().AddForce((posi - fire)*attack);
		}
	} else if (collider.tag == "item_frog") {
		var isfrog:boolean = anime.GetBool("Frog");
		if (!isfrog) {
			jumpPower *= 2.0f;
			anime.SetBool("Frog",true);
			Destroy(collider.gameObject, 1);
			var audio:AudioSource = collider.gameObject.GetComponent.<AudioSource>();
			audio.Play();
		}
	} else if (collider.tag == "item_fire") {
		fireEnabled = true;
		lightEnabled = false;
		greenEnabled = false;
		Destroy(collider.gameObject, 1);
	} else if (collider.tag == "item_lightning") {
		fireEnabled = false;
		lightEnabled = true;
		greenEnabled = false;
		Destroy(collider.gameObject, 1);
	} else if (collider.tag == "item_greenLight") {
		fireEnabled = false;
		lightEnabled = false;
		greenEnabled = true;
		Destroy(collider.gameObject, 1);
	}
}

function OnTriggerStay2D(collider:Collider2D) {
	stay_time += Time.deltaTime;
	if (exec_time > stay_time) {
		return;
	}
	stay_time = 0.0f;
	if (collider.tag.length > 5 && collider.tag.Substring(0,5) == "Chest") {
		var tchest:GameObject = collider.gameObject;
		if (Input.GetAxis("Fire1") > 0) {
			if (!hand_flag || hand_kame == null && hand_chest != null && hand_chest === tchest) {
				hand_flag = true;
				hand_chest = tchest;
				hand_kame = null;
				if (face.GetComponent.<Rigidbody2D>().mass <= GROUND_MASS) {
					var mass:float = 0.0f;
					switch (collider.tag) {
					case "Chest002": 
						mass = chest_002g;
						break;
					case "Chest007":
						mass = chest_007g;
						break;
					case "Chest010":
						mass = chest_010g;
						break;
					case "Chest030":
						mass = chest_030g;
						break;
					case "Chest050":
						mass = chest_050g;
						break;
					case "Chest100":
						mass = chest_100g;
						break;
					default:
						Debug.Log("unknown Chest:" + collider.tag	);
						return ;
					}
					face.GetComponent.<Rigidbody2D>().mass += mass;
					tchest.GetComponent.<Rigidbody2D>().mass = 0;
				}
				var vchest:Vector3 = tchest.transform.position;
				var posi:Vector3 = face.transform.position;

				if (vchest.x >= posi.x) {
					tchest.transform.position = posi + Vector3(0.4,0,0);
				} else if (vchest.x < posi.x) {
					tchest.transform.position = posi + Vector3(-0.4,0,0);
				}

				if (Input.GetAxis("Fire2") > 0) {
					this.gameObject.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
					var throwChestDirect:int = 1;
					if (rotateFlg) {
						throwChestDirect  = -1;
					}
					var tchest_posi:Vector3 = tchest.transform.position;
					tchest.transform.position = tchest_posi + Vector3(1.0 * throwChestDirect, 0, 0);
					tchest.GetComponent.<Rigidbody2D>().mass = mass * throwMass;
					tchest.GetComponent.<Rigidbody2D>().AddForce(Vector3(1,0,0)*throwChestDirect*throwPower);
					tchest.SendMessage("NowThrowing");
					hand_flag = false;
					hand_chest = null;
				}
			} else {
				hand_flag = false;
				hand_chest = null;
				tchest.SendMessage("SetMass");
				face.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
			}
		} else {
			hand_flag = false;
			hand_chest = null;
			tchest.SendMessage("SetMass");
			face.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
		}

		if (hand_flag) {
			anime.SetBool("Hand",true);
		} else {
			anime.SetBool("Hand",false);
		}

	} else if (collider.tag == "Kame") {
		var tkame:GameObject = collider.gameObject;
		if (Input.GetAxis("Fire1") > 0) {

			if (anime_kame == null) {
				anime_kame = tkame.GetComponentInChildren(Animator);
			}

			inkora = anime_kame.GetBool("InKora");

			if (inkora && (!hand_flag || hand_chest == null && hand_kame != null && hand_kame === tkame)) {
				hand_flag = true;
				hand_chest = null;
				hand_kame = tkame;
				if (face.GetComponent.<Rigidbody2D>().mass <= GROUND_MASS) {
					face.GetComponent.<Rigidbody2D>().mass += tkame.GetComponent.<Rigidbody2D>().mass;
					tkame.GetComponent.<Rigidbody2D>().mass = 0;
				}
				var vkame:Vector3 = tkame.transform.position;
				var posi2:Vector3 = face.transform.position;

				//var box_collider = tkame.GetComponentInChildren(BoxCollider2D);
				// box_collider.density = 0;

				if (vkame.x >= posi2.x) {		// 亀が右にいる
					if (rotateFlg) {
						tkame.transform.position = posi2 + Vector3(-0.4, 0, 0);
					} else {
						tkame.transform.position = posi2 + Vector3(0.4, 0, 0);
					}
				} else if (vkame.x < posi2.x) { // 亀が左にいる
					if (rotateFlg) {
						tkame.transform.position = posi2 + Vector3(-0.4, 0, 0);
					} else {
						tkame.transform.position = posi2 + Vector3(0.4, 0, 0);
					}
				}

				if (Input.GetAxis("Fire2") > 0) {
					this.gameObject.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
					var direct:int = 1;
					if (rotateFlg) {
						direct  = -1;
					}
					tkame.transform.position = vkame + Vector3(1.0 * direct, 0, 0);
					tkame.GetComponent.<Rigidbody2D>().mass = kame_g * throwMass;
					tkame.GetComponent.<Rigidbody2D>().AddForce(Vector2( 1, 0)*throwPower*direct);
					tkame.SendMessage("NowThrowing");
					this.gameObject.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
					hand_flag = false;
					hand_kame = null;
				}
			} else {
				hand_flag = false;
				hand_kame = null;
			}
		} else {
			hand_flag = false;
			hand_kame = null;
			anime_kame = null;
			if (face.GetComponent.<Rigidbody2D>().mass - GROUND_MASS > 0) {
				tkame.GetComponent.<Rigidbody2D>().mass = face.GetComponent.<Rigidbody2D>().mass - GROUND_MASS;
				face.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
			}
		}
		if (hand_flag) {
			anime.SetBool("Hand",true);
		} else {
			anime.SetBool("Hand",false);
		}

	} else {
//		hand_flag = false;
//		hand_chest = null;
//		anime_kame = null;
//		anime.SetBool("Hand",false);
	}
}

function OnTriggerExit2D(collider:Collider2D) {
	if (collider.tag == "Chest" || collider.tag == "Kame") {
		hand_flag = false;
		hand_chest = null;
		anime_kame = null;
		if (face.GetComponent.<Rigidbody2D>().mass - GROUND_MASS > 0) {
			collider.gameObject.GetComponent.<Rigidbody2D>().mass = face.GetComponent.<Rigidbody2D>().mass - GROUND_MASS;
			face.GetComponent.<Rigidbody2D>().mass = GROUND_MASS;
		}
		anime.SetBool("Hand",false);
	}
}

function IsGrounded(active:boolean) {
	isGrounded = active;
}

function InWater(active:boolean) {
	isWater = active;
}

function InSky(active:boolean) {
	isSky = active;
}

function InitRotate(value:boolean) {
	rotateFlg = value;
	//if (!isWater && !isSky) {
		anime.SetBool("Rotate", rotateFlg);
	//}
	Debug.Log("fase rotate:" + rotateFlg);
}