using System;
using System.Collections.Generic;

namespace XKCDevsTimeTracker
{
	public class TimeEntry
	{
		public TimeEntry()
		{
			this.StartTime = DateTime.Now;
		}

		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public List<BreakEvent> Breaks { get; set; }
		public string Description { get; set; }

		public TimeSpan TotalTimeWorked
		{
			get
			{
				TimeSpan total = (this.EndTime - this.StartTime);
				if (null == Breaks || 0 == Breaks.Count)
				{
					return total;
				}
				TimeSpan breaks = new TimeSpan();
				foreach (var Break in Breaks)
				{
					breaks.Add(Break.BreakDuration);
				}

				return total - breaks;
			}
		}

		public string DisplayString
		{
			get
			{
				string date = StartTime.ToString("MM/dd");
				string start = StartTime.ToString("HH:mm");
				string end = EndTime.ToString("HH:mm");
				string worked = TotalTimeWorked.ToString("g");

				return $"{date}: {start} - {end} ({worked})";
			}
		}

	}
}

