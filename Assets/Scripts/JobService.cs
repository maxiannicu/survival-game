using System;
using AssemblyCSharp;
using System.Collections;

namespace AssemblyCSharp {
	public sealed class JobService {
		
		private static Queue tasks = new Queue();

		private JobService() {
		}

		public static Queue GetTask() {
			return tasks;
		}

		public static void addTask(Task task) {
			tasks.Enqueue(task);
		}


	}
}
