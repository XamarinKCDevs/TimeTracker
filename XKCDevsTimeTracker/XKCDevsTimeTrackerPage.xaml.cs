using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XKCDevsTimeTracker
{
	public partial class XKCDevsTimeTrackerPage : ContentPage
	{
		TimeEntry current = null;
		BreakEvent currentBreak = null;
		List<TimeEntry> entries = new List<TimeEntry>();

		public XKCDevsTimeTrackerPage()
		{
			InitializeComponent();


			entries.Add(new TimeEntry
			{
				StartTime = new System.DateTime(2016, 09, 06, 04, 30, 00),
				EndTime = new System.DateTime(2016, 09, 06, 05, 30, 00),
				Description = "First Time Entry"
			});
			entries.Add(new TimeEntry
			{
				StartTime = new System.DateTime(2016, 09, 06, 05, 31, 00),
				EndTime = new System.DateTime(2016, 09, 06, 06, 30, 00),
				Description = "Second Time Entry"
			});
			entries.Add(new TimeEntry
			{
				StartTime = new System.DateTime(2016, 09, 06, 12, 31, 00),
				EndTime = new System.DateTime(2016, 09, 06, 13, 30, 00),
				Description = "Second Time Entry"
			});

			TimeEntriesListView.ItemsSource = entries;
		}

		protected void StartStopButtonClick(object sender, EventArgs e)
		{
			bool isStarting = (StartStopButton.Text.ToLower() == "start time");

			if (isStarting)
			{
				this.current = new TimeEntry { StartTime = DateTime.Now };
				StartStopButton.Text = "End Time";
				BreakButton.IsEnabled = true;
			}
			else { //isEnding:
				this.current.EndTime = DateTime.Now;
				entries.Add(current);
				StartStopButton.Text = "Start Time";
				TimeEntriesListView.ItemsSource = null;
				TimeEntriesListView.ItemsSource = entries;
				BreakButton.IsEnabled = false;
				TimeSpan total = TotalWork();
			}
			
		}

		protected void BreakButtonClick(object sender, EventArgs e)
		{
			if (this.currentBreak == null)
			{
				this.currentBreak = new BreakEvent { StartTime = DateTime.Now };
				BreakButton.Text = "End Break";
			}
			else
			{
				this.currentBreak.EndTime = DateTime.Now;
				if (this.current.Breaks == null) this.current.Breaks = new List<BreakEvent>();
				this.current.Breaks.Add(currentBreak);
				this.currentBreak = null;
				BreakButton.Text = "Start Break";
			}
		}

		protected TimeSpan TotalWork()
		{
			TimeSpan total = new TimeSpan();
			if (null == entries) return total;
			foreach (var entry in entries)
			{
				total.Add(entry.TotalTimeWorked);
			}
			return total;
		}
	
	}
}

