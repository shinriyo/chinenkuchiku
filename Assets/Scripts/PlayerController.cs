using System.Collections;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

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

		private Animator mAnimator;
		private BoxCollider2D mBoxcollier2D;
		private Rigidbody2D mRigidbody2D;
		private const float mCenterY = 1.5f;

		private State mState = State.Normal;

		void Reset ()
		{
			Awake ();

			this.backwardForce = new Vector2 (-4.5f, 5.4f);

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

			// Update代わり.
			this.UpdateAsObservable()
				.Select(_ => mState != State.Damaged)
				.Subscribe(_ =>
					{
						float x = Input.GetAxis ("Horizontal");
						float y = Input.GetAxis ("Vertical");
						this.Move (x, y);
					});
		}

		/// <summary>
		/// Move the specified move and y.
		/// </summary>
		/// <param name="x">Xのパラメータ.</param>
		/// <param name="y">Yのパラメータ.</param>
		void Move (float x, float y)
		{
			float addX = 0;
			float addY = 0;
			if (Mathf.Abs (x) > 0) {
				Quaternion rot = transform.rotation;
				transform.rotation = Quaternion.Euler (rot.x, Mathf.Sign (x) == 1 ? 0 : 180, rot.z);
			

				addX = x;
			} else if (Mathf.Abs (y) > 0) {
				addY = y;
			}

			mRigidbody2D.velocity = new Vector2 (addX * maxSpeed, addY * maxSpeed);

			mAnimator.SetFloat ("Horizontal", x);
			mAnimator.SetFloat ("Vertical", y);
		}

		/// <summary>
		/// Fixeds the update.
		/// </summary>
		void FixedUpdate ()
		{
		}

		void OnTriggerStay2D (Collider2D other)
		{
			if (other.tag == "DamageObject" && mState == State.Normal) {
				mState = State.Damaged;
				StartCoroutine (INTERNAL_OnDamage ());
			}
		}

		/// <summary>
		/// INTERNAs the l on damage.
		/// </summary>
		/// <returns>The l on damage.</returns>
		IEnumerator INTERNAL_OnDamage ()
		{
			mAnimator.Play ("Damage");
			mAnimator.Play ("Idle");

			SendMessage ("OnDamage", SendMessageOptions.DontRequireReceiver);

			yield return new WaitForSeconds (.2f);

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
