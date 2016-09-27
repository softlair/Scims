using Slair.Scims.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slair.Scims.Dal
{
	public class ScimsDbInitializer
	{
		private static ScimsDbContext _context;

		public static void Initialize (IServiceProvider serviceProvider)
		{
			_context = (ScimsDbContext)serviceProvider.GetService (typeof (ScimsDbContext));

			InitializeSchedules ( );
		}

		private static void InitializeSchedules ( )
		{
			var dateNow = DateTime.Now;

			if (!_context.ShiftDescriptions.Any ( )) {
				var shift1 = new ShiftDescription {
					Name = "7-4",
					Description = "1st shift",
					StartTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 7, 0, 0),
					EndTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 16, 0, 0),
					Notes = "Default Shift",
					ArchiveFlag = false
				};

				var shift2 = new ShiftDescription {
					Name = "8-5",
					Description = "Management shift",
					StartTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 8, 0, 0),
					EndTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 17, 0, 0),
					Notes = "Shifts for Management Positions",
					ArchiveFlag = false
				};
				var shift3 = new ShiftDescription {
					Name = "1-10",
					Description = "Afternoon Shift",
					StartTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 13, 0, 0),
					EndTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 22, 0, 0),
					Notes = "Special Afternoon Shift",
					ArchiveFlag = false
				};
				var shift4 = new ShiftDescription {
					Name = "3-12",
					Description = "2nd Shift",
					StartTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 13, 0, 0),
					EndTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 22, 0, 0),
					Notes = "2nd shift",
					ArchiveFlag = false
				};
				var shift5 = new ShiftDescription {
					Name = "10-7",
					Description = "3rd Shift",
					StartTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 22, 0, 0),
					EndTime = new DateTime (dateNow.Year, dateNow.Month, dateNow.Day + 1, 7, 0, 0),
					Notes = "3rd shift",
					ArchiveFlag = false
				};

				_context.ShiftDescriptions.Add (shift1);
				_context.ShiftDescriptions.Add (shift2);
				_context.ShiftDescriptions.Add (shift3);
				_context.ShiftDescriptions.Add (shift4);
				_context.ShiftDescriptions.Add (shift5);

				_context.SaveChanges ( );
			}

			if (!_context.TaskDescriptions.Any ( )) {
				var taskDesc1 = new TaskDescription {

					//public int Category { get; set; }
					//public string Code { get; set; }
					//public string Name { get; set; }
					//public string Description { get; set; }
					//public string Notes { get; set; }
					//public ICollection<ITaskDescription<string>> SubTasks { get; set; }
					//public bool ArchiveFlag { get; set; }
					//public ICollection<IProjectDescription<string>> Projects { get; set; }
				};
			}
		}
	}
}
