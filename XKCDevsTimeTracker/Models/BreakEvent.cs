using System;
namespace XKCDevsTimeTracker
{
	public class BreakEvent
	{
		public BreakEvent()
		{
		}

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		//public string Description { get; set; }

		public TimeSpan BreakDuration
		{
			get
			{
				TimeSpan dur = this.EndTime - this.StartTime;
				return dur;
		}
		}
	}
}

