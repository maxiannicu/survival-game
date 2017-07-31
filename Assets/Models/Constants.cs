using UnityEngine;

public static class Constants {
	public static class Game {
		public const int InitialCapsules = 0;
		public const int MaxCapsules = 10;
		public const int MaxCapsulesOnMapAtTime = 20;
		public const int PeriodTime = 10;
		public const int CapsuleSpawnInterval = 1;
		public const int MaxBuyDelayBetweenButtons = 3000;
	}

	public static class Animation {
		public const float PeriodSwitch = 3.0f;
		public const float PeriodSwitchDownBarier = 0.6f;
	}

	public static class Limits {
		public const float LeftSide = -12f;
		public const float RightSide = 15f;
	}
}
