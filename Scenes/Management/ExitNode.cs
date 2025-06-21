using Godot;

namespace AlchemyProject.Management {
	public partial class ExitNode : Area2D {
		[Export] public string id;
		[Export] public string target;

		public void OnCollision(Node2D body) {
			if (body is Entities.Lunei.Lunei) {
				SceneManager.instance.ChangeMap(target, id);
			}
		}
	}
}
