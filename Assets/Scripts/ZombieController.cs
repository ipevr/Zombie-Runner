using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class ZombieController : MonoBehaviour {

		public Avatar avatarWalk;
		public Avatar avatarAttack;
		public float attackDistance = 2f;

		private Animator zombieAnimator;
		private AICharacterControl aiCharacterControl;
		private float distance;

		// Use this for initialization
		void Start () {
			aiCharacterControl = GetComponent<AICharacterControl> ();
			zombieAnimator = GetComponent<Animator> ();
			zombieAnimator.avatar = avatarWalk;
		}
		
		// Update is called once per frame
		void Update () {
			distance = Vector3.Distance(transform.position, aiCharacterControl.target.transform.position);
			if (distance <= attackDistance) {
				Attack ();
			} else {
				Walk ();
			}
		}

		private void Attack() {
			zombieAnimator.avatar = avatarAttack;
			zombieAnimator.SetBool ("IsAttacking", true);
		}

		private void Walk() {
			zombieAnimator.avatar = avatarWalk;
			zombieAnimator.SetBool ("IsAttacking", false);
		}

	}

}
