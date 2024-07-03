using Microsoft.AspNetCore.Mvc;

namespace WorkTimeTracking.Models
{
    public class WorkReport
    {
        public int Id { get; private set; }
        public string Note { get; private set; }
        public int Hours { get; private set; }
        public DateTime Date { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }

        private WorkReport() { }

        public WorkReport(int id, string note, int hours, DateTime date, int userId)
        {
            Id = id;
            Note = note;
            Hours = hours;
            Date = date;
            UserId = userId;
        }

        public WorkReport(string note, int hours, DateTime date, int userId)
        {
            Note = note;
            Hours = hours;
            Date = date;
            UserId = userId;
        }

        public void UpdateDetails(string note, int hours, DateTime date, int userId)
        {
            Note = note;
            Hours = hours;
            Date = date;
            UserId = userId;
        }
    }
}