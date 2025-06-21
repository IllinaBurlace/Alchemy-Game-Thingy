using Godot;
using System;

namespace AlchemyProject.Entities.Lunei.States {
	public partial class Idle : State {
		public override void Enter(CharacterBody2D entity) {
			base.Enter(entity);

			((Lunei)parent).animationController.state = "idle";
		}

		public override State StateProc() {
			if (Input.GetVector("left", "right", "up", "down") != Vector2.Zero)
					return new Move();
			return null;
		}
	}
}
