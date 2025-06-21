using Godot;

namespace AlchemyProject.Entities.Lunei {
	public partial class AnimationController : AnimatedSprite2D {
		public Vector2 direction = new(0, 0);
		public string state;
		public string anim = "_right";
		
		public override void _Process(double delta) {
			bool left = false;
			if (direction[0] < 0)
				left = true;
			if (direction[0] > 0)
				left = false;

			direction = direction.Round();

			switch (direction)
			{
				case Vector2(0, 0):
					break;
			    case Vector2(1, 0):
					anim = "_right";
					break;
				case Vector2(-1, 0):
					anim = "_left";
					break;
				case Vector2(0, -1):
					anim = "_up";
					break;
				case Vector2(1, -1):
					anim = "_diag_right";
					break;
				case Vector2(-1, -1):
					anim = "_diag_left";
					break;
			    default:
					if (left)
						anim = "_left";
					else
						anim = "_right";
					break;
			}

			Play(state + anim);
		}
	}
}
