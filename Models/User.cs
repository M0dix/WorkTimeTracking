namespace WorkTimeTracking.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Patronymic { get; private set; }

        private User() { }

        public User(int id, string email, string firstName, string lastName, string patronymic)
        {
            ValidateRequiredFields(email, firstName, lastName, patronymic);

            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public User(string email, string firstName, string lastName, string patronymic)
        {
            ValidateRequiredFields(email, firstName, lastName, patronymic);

            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        private void ValidateRequiredFields(string email, string firstName, string lastName, string patronymic)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "Email is required");
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "First name is required");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Last name is required");
            }

            if (string.IsNullOrEmpty(patronymic))
            {
                throw new ArgumentNullException(nameof(patronymic), "Patronymic is required");
            }
        }

        public void UpdateDetails(string email, string firstName, string lastName, string patronymic)
        {
            ValidateRequiredFields(email, firstName, lastName, patronymic);

            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public List<WorkReport> WorkReports { get; private set; }
    }
}
