using Godot;
using System;

namespace AlchemyProject.Entities.Lunei.States {
	public partial class Move : State {
		const float SPEED = 300.0f;
		Vector2 direction;

		public override void Enter(CharacterBody2D entity) {
			base.Enter(entity);

			((Lunei)parent).animationController.state = "move";
		}

		public override void Phys(double delta) {
			direction = Input.GetVector("left", "right", "up", "down");
			parent.Velocity = direction * SPEED;
			parent.MoveAndSlide();
			((Lunei)parent).animationController.direction = direction;
		}

		public override State StateProc() {
			if (direction == Vector2.Zero) 
				return new Idle();
			return null;
		}
	}
}
