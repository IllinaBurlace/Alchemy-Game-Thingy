using Godot;

namespace AlchemyProject.Entities.Lunei {
	public partial class Lunei : CharacterBody2D {
		public State currentState;
		public AnimationController animationController;

		public void Machine() {
			State newState = currentState.StateProc();
			if (newState != null) {
				currentState.Exit();
				currentState = newState;
				currentState.Enter(this);
			}
		}

		public override void _Ready() {
			animationController = GetNode<AnimationController>("AnimatedSprite2D");

			currentState = new States.Idle();
			currentState.Enter(this);
		}

		public override void _Process(double delta) {
			currentState.Frame(delta);
			Machine();
		}

		public	override void _PhysicsProcess(double delta) {
			currentState.Phys(delta);
		}
	}
}
