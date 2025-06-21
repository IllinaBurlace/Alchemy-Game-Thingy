using Godot;

namespace AlchemyProject.Management {
	public partial class SceneManager : Node2D {
		public static SceneManager instance { get; private set; }
		Entities.Lunei.Lunei lunei;
		Node2D map;

		public override void _Ready() {
			instance = this;

			lunei = (Entities.Lunei.Lunei)GD.Load<PackedScene>(@"res://Scenes/Entities/Lunei/Lunei.tscn").Instantiate();
			map = (Node2D)GD.Load<PackedScene>(@"res://Scenes/Maps/Home/Bedroom.tscn").Instantiate();

			AddChild(map);
			AddChild(lunei);
			EntryNode entryNode = (EntryNode)GetTree().GetFirstNodeInGroup("EntryNode");
			lunei.GlobalPosition = entryNode.GlobalPosition;

			string[] anim = entryNode.anim.Split('_');
			lunei.animationController.state = anim[0];
			lunei.animationController.anim = "_" + anim[1];
		}

		public void ChangeMap(string target, string id) {
			CallDeferred("remove_child", map);
			map = (Node2D)GD.Load<PackedScene>(target).Instantiate();
			CallDeferred("LoadMap", id);
		}
		
		void LoadMap(string id) {
			AddChild(map);

			foreach (EntryNode node in GetTree().GetNodesInGroup("EntryNode")) {
				if (node.id == id) {
					lunei.GlobalPosition = node.GlobalPosition;
					string[] anim = node.anim.Split('_');
					lunei.animationController.state = anim[0];
					lunei.animationController.anim = "_" + anim[1];
					break;
				}
			}
		}
	}
}
