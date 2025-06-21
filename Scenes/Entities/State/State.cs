using Godot;
using System;

namespace AlchemyProject.Entities {
	public partial class State : Node {
		public CharacterBody2D parent;
		
		public virtual void Enter(CharacterBody2D entity) {
			parent = entity;
		}

		public virtual void Exit() {}

		public virtual void Frame(double delta) {}

		public virtual void Phys(double delta) {}

		public virtual State StateProc() {
			return null;
		}
	}
}
