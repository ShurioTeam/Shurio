using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aorio : MonoBehaviour
{
	public int jumpPower = 10;
	public int power = 10;
	public float throwPower = 1.0f;
	public float throwMass = 10.0f;
	public GameObject face;
	public int attack = 1000;
	public GameObject fireflow;
	public GameObject lightflow;
	public GameObject greenflow;
	private bool jumping = false;
	private Animator anime;
	private Animator anime_kame;
	private bool rotateFlg;
	private float timer;
	public int nTimer = 5;
	public float GROUND_MASS = 1.0f;
	public GameObject chest;
	public GameObject kame;
	private static bool hand_flag = false;
	private static GameObject hand_chest;
	private static GameObject hand_kame;
	private bool inkora = false;
	public float walk_divide = 100.0f;
	public GameObject chest002;
	public GameObject chest007;
	public GameObject chest010;
	public GameObject chest030;
	public GameObject chest050;
	public GameObject chest100;
	public GameObject bom;
	private float chest_002g = 0.0f;
	private float chest_007g = 0.0f;
	private float chest_010g = 0.0f;
	private float chest_030g = 0.0f;
	private float chest_050g = 0.0f;
	private float chest_100g = 0.0f;
	private float kame_g = 0.0f;
	private float fire_time;
	private bool isGrounded = false;
	private bool isWater = false;
	private bool isSky = false;
	private bool fireEnabled = false;
	private bool lightEnabled = false;
	private bool greenEnabled = false;
	private bool bomEnabled = false;
	private Quaternion muki;
	private float InputX = 0;
	private float InputY = 0;
	private bool hasKey = false;
	private bool hasKeyBox = false;
	private bool setGlam = false;
	private Vector3 faceScale;

    // Start is called before the first frame update
    void Start()
    {
		anime = face.GetComponentInChildren<Animator>();
		GROUND_MASS = face.GetComponent<Rigidbody2D>().mass;
		faceScale = face.transform.localScale;
		if (walk_divide == 0) {
			walk_divide = 100.0f;
		}
		fire_time = 5.0f;
		rotateFlg = false;       
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("Horizontal_Joy2:" + Input.GetAxis("Horizontal_Joy2"));
		Debug.Log("Vertical_Joy2:" + Input.GetAxis("Vertical_Joy2"));
		Debug.Log("RT_Joy2:" + Input.GetAxis("RT_Joy2"));
		Debug.Log("LT_Joy2:" + Input.GetAxis("LT_Joy2"));

		Debug.Log("X:" + Input.GetAxis("Fire3"));
		Debug.Log("Y:" + Input.GetAxis("Jump"));
		Debug.Log("A:" + Input.GetAxis("Enter"));
		Debug.Log("B:" + Input.GetAxis("Fire1"));
		Debug.Log("RB:" + Input.GetAxis("Fire2"));
		Debug.Log("LB:" + Input.GetAxis("Fire4"));
		Debug.Log("Back:" + Input.GetAxis("Back"));
		Debug.Log("Start:" + Input.GetAxis("Start"));
		if (!setGlam) {
			if (chest002 != null && chest_002g == 0.0f) chest_002g = chest002.GetComponent<Rigidbody2D>().mass;
			if (chest007 != null && chest_007g == 0.0f) chest_007g = chest007.GetComponent<Rigidbody2D>().mass;
			if (chest010 != null && chest_010g == 0.0f) chest_010g = chest010.GetComponent<Rigidbody2D>().mass;
			if (chest030 != null && chest_030g == 0.0f) chest_030g = chest030.GetComponent<Rigidbody2D>().mass;
			if (chest050 != null && chest_050g == 0.0f) chest_050g = chest050.GetComponent<Rigidbody2D>().mass;
			if (chest100 != null && chest_100g == 0.0f) chest_100g = chest100.GetComponent<Rigidbody2D>().mass;
			if (kame != null && kame_g == 0.0f) kame_g = kame.GetComponent<Rigidbody2D>().mass;
			setGlam = true;
		}

		if (isWater && !isGrounded) {
			return ;
		}

		if (!isWater) {
			isGrounded = true;
			face.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
			anime.SetBool("Swim", false);
		}

		InputX = Input.GetAxis("Horizontal_Joy2");

		InputY = Input.GetAxis("Vertical_Joy2");

//		InputX += Input.acceleration.x;
//		InputY += -1 * Input.acceleration.y;

		Vector2 inputDirection = new Vector2(InputX, InputY);
		Vector3 posi = face.transform.position;

		muki = face.transform.rotation;
		//Camera camera = this.gameObject.GetComponentInChildren<Camera> ();
		if (muki.y < -0.0) {
			rotateFlg = true;
			anime.SetBool("Rotate", true);
			//camera.transform.position = new Vector3(0, 0, 50f);
		} else {
			rotateFlg = false;
			anime.SetBool("Rotate", false);
			//camera.transform.position = new Vector3(0, 0, -50f);
		}

		if (!isWater && InputX > 0) {
			if (rotateFlg) {
				face.transform.Rotate(0, 180, 0);
				if (hand_flag) {
					face.transform.position += new Vector3(-0.5f,0,0);
				} else {
					face.transform.position += new Vector3(-0.2f,0,0);
				}
			}
		}

		if (!isWater && InputX < 0) {
			if (!rotateFlg) {
				face.transform.Rotate(0, 180, 0);
				if (hand_flag) {
					face.transform.position += new Vector3(0.5f,0,0);
				} else {
					face.transform.position += new Vector3(0.2f,0,0);
				}
			}
		}

		if (inputDirection.magnitude > 0.1) {
			anime.SetFloat("WorkSpeed",2);
		} else {
			anime.SetFloat("WorkSpeed", 0);
		}

		if (isGrounded && InputY > 0.7) {
			anime.SetBool("Jump", true);
		} else {
			anime.SetBool("Jump",false);
		}

		fire_time += Time.deltaTime * 1.0f;

		timer += Time.deltaTime;
		if (timer > nTimer * Time.deltaTime) {
			anime.SetBool("Hit", false);
		}

//		float fire1 = Input.GetAxis("Fire1");
//		float InputUp = Input.GetAxis("Vertical");
		bool fire1 = Input.GetKey(KeyCode.S);
		bool InputUp = Input.GetKey(KeyCode.Keypad8);
		if (fire1 && InputUp) {
			anime.SetBool("UpperAttack", true);
			anime.SetBool("LowAttack", false);
			anime.SetBool("MiddleAttack", false);
		}  else if (fire1 && !InputUp) {
			anime.SetBool("UpperAttack", false);
			anime.SetBool("LowAttack", true);
			anime.SetBool("MiddleAttack", false);
		} else if (fire1) {
			anime.SetBool("UpperAttack", false);
			anime.SetBool("LowAttack", false);
			anime.SetBool("MiddleAttack", true);
		} else {
			anime.SetBool("UpperAttack", false);
			anime.SetBool("LowAttack", false);
			anime.SetBool("MiddleAttack", false);
		}
    }

	void FixedUpdate() 
	{
		if (isWater && !isGrounded) {
			return ;
		}

		var leadTime = Time.fixedDeltaTime;

		if (!isWater && InputX > 0) {
			face.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,0)*InputX*power);
			face.transform.position += new Vector3(1,0,0)*InputX/walk_divide;
		}

		if (!isWater && InputX < 0) {
			face.GetComponent<Rigidbody2D>().AddForce(new Vector2(1,0)*InputX*power);
			face.transform.position += new Vector3(1,0,0)*InputX/walk_divide;
		}

		if (!isWater && InputY > 0.7 && !jumping) {
			face.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1)*jumpPower);
			face.transform.position += new Vector3(0,0.5f,0);
			jumping = true;
			isGrounded = false;
		}

		bool touchFlag = false;
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			touchFlag = touch.phase == TouchPhase.Began;
		}
		if (Input.GetKey(KeyCode.Z) || touchFlag) {
			Debug.Log("FireEnabled:" + fireEnabled);
			if (fireflow != null && fireEnabled) {
				if (fire_time > 0.5f) {
					fire_time = 0.0f;
					GameObject _fireflow = GameObject.Instantiate(fireflow, this.transform.position, Quaternion.identity);
					_fireflow.SetActive(true);
					_fireflow.GetComponent<Rigidbody2D>().AddTorque(90);

					if (rotateFlg) {
						_fireflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 0));
					} else {
						_fireflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));
					}

					// Destroy(_fireflow, 5.0f);
				}
			} else if (lightflow != null && lightEnabled) {
				if (fire_time > 0.2f) {
					fire_time = 0.0f;
					Vector3 margin = new Vector3(0.5f, 0, 0);
					if (rotateFlg) {
						margin *= -1;
					}
					GameObject _lightflow = GameObject.Instantiate(lightflow, this.transform.position + margin, Quaternion.identity);
					_lightflow.SetActive(true);
					_lightflow.GetComponent<Rigidbody2D>().AddTorque(90);

					if (rotateFlg) {
						_lightflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-60, 30));
					} else {
						_lightflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(60, 30));
					}

					Destroy(_lightflow, 10.0f);
				}
			} else if (greenflow != null && greenEnabled) {
				if (fire_time > 0.2f) {
					fire_time = 0.0f;
					Vector3 margin = new Vector3(1.5f, 0, 0);
					if (rotateFlg) {
						margin *= -1;
					}
					GameObject _greenflow = GameObject.Instantiate(greenflow, this.transform.position + margin, Quaternion.identity);
					_greenflow.SetActive(true);

					if (rotateFlg) {
						_greenflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 3));
					} else {
						_greenflow.GetComponent<Rigidbody2D>().AddTorque(180);
						_greenflow.GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 3));
					}

					Destroy(_greenflow, 10.0f);
				}
			} else if (bom != null && bomEnabled) {
				if (fire_time > 5.0f) {
					fire_time = 0.0f;
					Vector3 margin = new Vector3(1.5f, 0, 0);
					if (rotateFlg) {
						margin *= -1;
					}
					GameObject _bom = GameObject.Instantiate(bom, this.transform.position + margin, Quaternion.identity);
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if (collider.gameObject.name == "fire" || collider.gameObject.name == "greenLight" || collider.gameObject.name == "lighting") {
			Debug.Log("Item is using");
			return;
		}
		if (jumping) {
			jumping = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Fire" || collider.tag == "Enemy") {
			bool attacking = Input.GetKey(KeyCode.S);
			Vector3 fire = collider.transform.position;
			Vector3 posi = face.transform.position;
			Vector3 direction = fire - posi;

			if (attacking) {
				// シュリオが攻撃していた場合
				face.GetComponent<AudioSource>().Play();
				collider.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, attack, 0));
				collider.GetComponent<Rigidbody2D>().AddForce((fire - posi)*attack);
			} else {
				if (collider.tag == "Fire" || direction.y >= 0) {
					anime.SetBool("Hit",true);
					timer = 0.0f;
					AudioSource asrc = collider.GetComponent<AudioSource>();
					if (asrc != null) {
						asrc.Play();
					}
					face.GetComponent<Rigidbody2D>().AddForce((posi - fire)*attack);
				}
			}
		} else if (collider.tag == "item_bom") {
			collider.SendMessage("InvokeSwitchOn", 7.0f);
		} else if (collider.tag == "item_frog") {
			bool isfrog = anime.GetBool("Frog");
			if (!isfrog) {
				jumpPower *= 2;
				anime.SetBool("Frog",true);
				Destroy(collider.gameObject, 1);
				AudioSource audio = collider.gameObject.GetComponent<AudioSource>();
				audio.Play();
			}
		} else if (collider.tag == "item_fire") {
			fireEnabled = true;
			lightEnabled = false;
			greenEnabled = false;
			bomEnabled = false;
			Destroy(collider.gameObject, 1);
			Debug.Log("SetFireEnabled:" + fireEnabled);
		} else if (collider.tag == "item_lightning") {
			fireEnabled = false;
			lightEnabled = true;
			greenEnabled = false;
			bomEnabled = false;
			Destroy(collider.gameObject, 1);
		} else if (collider.tag == "item_greenLight") {
			fireEnabled = false;
			lightEnabled = false;
			greenEnabled = true;
			bomEnabled = false;
			Destroy(collider.gameObject, 1);
		} else if (collider.tag == "key") {
			hasKey = true;
			Destroy(collider.gameObject, 2);
		} else if (collider.tag == "keyBox" && hasKey) {
			hasKeyBox = true;
			Destroy(collider.gameObject, 2);
			GameObject door = GameObject.Find("NextStageDoor");
			door.SendMessage("SetHasKeyBox", hasKeyBox);
		} else if (collider.tag == "bom") {
			Debug.Log("BOM:" + bomEnabled);
			bomEnabled = true;
			fireEnabled = false;
			lightEnabled = false;
			greenEnabled = false;
			Destroy(collider.gameObject, 1);
		}

	}

	void OnTriggerStay2D(Collider2D collider) {
		if (collider.tag.Length > 5 && collider.tag.Substring(0,5) == "Chest") {
			GameObject tchest = collider.gameObject;
			if (Input.GetKey(KeyCode.A)) {
				if (!hand_flag || (hand_kame == null && hand_chest != null && hand_chest == tchest)) {
					hand_flag = true;
					hand_chest = tchest;
					hand_kame = null;
					float diff = 0.0f;
					float mass = 0.0f;
					switch (collider.tag) {
					case "Chest002": 
						mass = chest_002g;
						diff = 0.3f;
						break;
					case "Chest007":
						mass = chest_007g;
						diff = 0.3f;
						break;
					case "Chest010":
						mass = chest_010g;
						diff = 0.4f;
						break;
					case "Chest030":
						mass = chest_030g;
						diff = 0.4f;
						break;
					case "Chest050":
						mass = chest_050g;
						diff = 0.4f;
						break;
					case "Chest100":
						mass = chest_100g;
						diff = 0.5f;
						break;
					default:
						Debug.Log("unknown Chest:" + collider.tag	);
						return ;
					}
					if (face.GetComponent<Rigidbody2D>().mass <= GROUND_MASS) {
						face.GetComponent<Rigidbody2D>().mass += mass;
						tchest.GetComponent<Rigidbody2D>().mass = 0.05f;
					}
					Vector3 vchest = tchest.transform.position;
					Vector3 posi = face.transform.position;

					if (vchest.x >= posi.x) {
						tchest.transform.position = posi + new Vector3(diff,0,0);
					} else if (vchest.x < posi.x) {
						tchest.transform.position = posi + new Vector3(-1 * diff,0,0);
					}

					if (Input.GetKey(KeyCode.D)) {
						this.gameObject.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
						int throwChestDirect = 1;
						if (rotateFlg) {
							throwChestDirect  = -1;
						}
						Vector3 tchest_posi = tchest.transform.position;
						tchest.transform.position = tchest_posi + new Vector3(1.0f * throwChestDirect, 0, 0);
						tchest.GetComponent<Rigidbody2D>().mass = GROUND_MASS * throwMass;
						tchest.GetComponent<Rigidbody2D>().AddForce(new Vector3(1,0,0)*throwChestDirect*throwPower);
						tchest.SendMessage("NowThrowing");
						hand_flag = false;
						hand_chest = null;
					}
				}
			} else {
				hand_flag = false;
				hand_chest = null;
				tchest.SendMessage("SetMass");
				face.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
			}

			if (hand_flag) {
				anime.SetBool("Hand",true);
			} else {
				anime.SetBool("Hand",false);
			}

		} else if (collider.tag == "Kame" || collider.tag == "item_bom") {
			GameObject tkame = collider.gameObject;
			if (Input.GetKey(KeyCode.S)) {

				if (anime_kame == null) {
					anime_kame = tkame.GetComponentInChildren<Animator>();
				}

				inkora = anime_kame.GetBool("InKora");

				if (inkora && (!hand_flag || hand_chest == null && hand_kame != null && hand_kame == tkame)) {
					hand_flag = true;
					hand_chest = null;
					hand_kame = tkame;
					if (face.GetComponent<Rigidbody2D>().mass <= GROUND_MASS) {
						face.GetComponent<Rigidbody2D>().mass += tkame.GetComponent<Rigidbody2D>().mass;
						tkame.GetComponent<Rigidbody2D>().mass = 0;
					}
					Vector3 vkame = tkame.transform.position;
					Vector3 posi2 = face.transform.position;

					//var box_collider = tkame.GetComponentInChildren(BoxCollider2D);
					// box_collider.density = 0;

					if (vkame.x >= posi2.x) {		// 亀が右にいる
						if (rotateFlg) {
							tkame.transform.position = posi2 + new Vector3(-0.4f, 0, 0);
						} else {
							tkame.transform.position = posi2 + new Vector3(0.4f, 0, 0);
						}
					} else if (vkame.x < posi2.x) { // 亀が左にいる
						if (rotateFlg) {
							tkame.transform.position = posi2 + new Vector3(-0.4f, 0, 0);
						} else {
							tkame.transform.position = posi2 + new Vector3(0.4f, 0, 0);
						}
					}

					if (Input.GetKey(KeyCode.D)) {
						this.gameObject.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
						int direct = 1;
						if (rotateFlg) {
							direct  = -1;
						}
						tkame.transform.position = vkame + new Vector3(1.0f * direct, 0, 0);
						tkame.GetComponent<Rigidbody2D>().mass = kame_g * throwMass;
						tkame.GetComponent<Rigidbody2D>().AddForce(new Vector2( 1, 0)*throwPower*direct);
						tkame.SendMessage("NowThrowing");
						this.gameObject.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
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
				if (face.GetComponent<Rigidbody2D>().mass - GROUND_MASS > 0) {
					tkame.GetComponent<Rigidbody2D>().mass = face.GetComponent<Rigidbody2D>().mass - GROUND_MASS;
					face.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
				}
			}
			if (hand_flag) {
				anime.SetBool("Hand",true);
			} else {
				anime.SetBool("Hand",false);
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "Chest" || collider.tag == "Kame") {
			hand_flag = false;
			hand_chest = null;
			anime_kame = null;
			if (face.GetComponent<Rigidbody2D>().mass - GROUND_MASS > 0) {
				collider.gameObject.GetComponent<Rigidbody2D>().mass = face.GetComponent<Rigidbody2D>().mass - GROUND_MASS;
				face.GetComponent<Rigidbody2D>().mass = GROUND_MASS;
			}
			anime.SetBool("Hand",false);
		}
	}

	void IsGrounded(bool active) {
		isGrounded = active;
	}

	void InWater(bool active) {
		isWater = active;
	}

	void InSky(bool active) {
		isSky = active;
	}

	void InitRotate(bool value) {
		rotateFlg = value;
		//if (!isWater && !isSky) {
		anime.SetBool("Rotate", rotateFlg);
		//}
		Debug.Log("fase rotate:" + rotateFlg);
	}

	public void CallAllItemsRemove(bool remove) {
		if (remove) {
			Invoke("AllItemsRemove", 3.0f);
		}
	}

	public void AllItemsRemove() {
		bomEnabled = false;
		fireEnabled = false;
		lightEnabled = false;
		greenEnabled = false;
		bool isfrog = anime.GetBool("Frog");
		if (isfrog) {
			jumpPower /= 2;
			anime.SetBool("Frog",false);
		}
		this.setDefaultSize();
	}

	public void setDefaultSize() {
		face.transform.localScale = faceScale;
	}
}
