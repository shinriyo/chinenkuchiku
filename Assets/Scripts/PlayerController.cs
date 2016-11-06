using System.Collections;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Player controller.
	/// </summary>
	[RequireComponent (typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private float maxSpeed = 10f;

		[SerializeField]
		private float jumpPower = 1000f;

		[SerializeField]
		private Vector2 backwardForce = new Vector2 (-4.5f, 5.4f);

//		[SerializeField]
//		private LayerMask whatIsGround;

		private Animator mAnimator;
		private BoxCollider2D mBoxcollier2D;
		private Rigidbody2D mRigidbody2D;
//		private bool mIsGround;
		private const float mCenterY = 1.5f;

		private State mState = State.Normal;

		void Reset ()
		{
			Awake ();

			// UnityChan2DController
			maxSpeed = 10f;
			jumpPower = 1000;
			backwardForce = new Vector2 (-4.5f, 5.4f);
//			whatIsGround = 1 << LayerMask.NameToLayer ("Ground");

			// Transform
			transform.localScale = new Vector3 (1, 1, 1);

			// Rigidbody2D
			mRigidbody2D.gravityScale = 3.5f;
			mRigidbody2D.fixedAngle = true;

			// BoxCollider2D
			mBoxcollier2D.size = new Vector2 (1, 2.5f);
			mBoxcollier2D.offset = new Vector2 (0, -0.25f);

			// Animator
			mAnimator.applyRootMotion = false;
		}

		void Awake ()
		{
			mAnimator = GetComponent<Animator> ();
			mBoxcollier2D = GetComponent<BoxCollider2D> ();
			mRigidbody2D = GetComponent<Rigidbody2D> ();
		}

		void Update ()
		{
			if (mState != State.Damaged) {
				float x = Input.GetAxis ("Horizontal");
				float y = Input.GetAxis ("Vertical");
//				bool jump = Input.GetButtonDown ("Jump");
//				Move (x, jump);
				this.Move (x, y);
			}
		}

//		void Move (float move, bool jump)
		void Move (float move, float y)
		{
			if (Mathf.Abs (move) > 0) {
				Quaternion rot = transform.rotation;
				transform.rotation = Quaternion.Euler (rot.x, Mathf.Sign (move) == 1 ? 0 : 180, rot.z);
			}

//			mRigidbody2D.velocity = new Vector2 (move * maxSpeed, mRigidbody2D.velocity.y);
			mRigidbody2D.velocity = new Vector2 (move * maxSpeed, y * maxSpeed);

			mAnimator.SetFloat ("Horizontal", move);
//			mAnimator.SetFloat ("Vertical", mRigidbody2D.velocity.y);
			mAnimator.SetFloat ("Vertical", y);
//			mAnimator.SetBool ("isGround", mIsGround);
			mAnimator.SetBool ("isGround", true);

//			if (jump && mIsGround) {
//				mAnimator.SetTrigger ("Jump");
//				SendMessage ("Jump", SendMessageOptions.DontRequireReceiver);
//				mRigidbody2D.AddForce (Vector2.up * jumpPower);
//			}
		}

		void FixedUpdate ()
		{
			Vector2 pos = transform.position;
			Vector2 groundCheck = new Vector2 (pos.x, pos.y - (mCenterY * transform.localScale.y));
//			Vector2 groundArea = new Vector2 (mBoxcollier2D.size.x * 0.49f, 0.05f);

//			mIsGround = Physics2D.OverlapArea (groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
//			mAnimator.SetBool ("isGround", mIsGround);
		}

		void OnTriggerStay2D (Collider2D other)
		{
			if (other.tag == "DamageObject" && mState == State.Normal) {
				mState = State.Damaged;
				StartCoroutine (INTERNAL_OnDamage ());
			}
		}

		IEnumerator INTERNAL_OnDamage ()
		{
//			mAnimator.Play (mIsGround ? "Damage" : "AirDamage");
			mAnimator.Play ("Idle");

			SendMessage ("OnDamage", SendMessageOptions.DontRequireReceiver);

			mRigidbody2D.velocity = new Vector2 (transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);

			yield return new WaitForSeconds (.2f);

//			while (mIsGround == false) {
//				yield return new WaitForFixedUpdate ();
//			}
			mAnimator.SetTrigger ("Invincible Mode");
			mState = State.Invincible;
		}

		void OnFinishedInvincibleMode ()
		{
			mState = State.Normal;
		}

		enum State
		{
			Normal,
			Damaged,
			Invincible,
		}
	}
}
