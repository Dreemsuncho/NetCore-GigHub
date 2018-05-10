using FluentValidation;
using System;
using System.Globalization;

namespace NetCore_GigHub.ViewModels
{
    public class ViewModelGig
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int GenreId { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.ParseExact(
                s: $"{Date} {Time}",
                format: "yyyy-MM-dd HH:mm",
                provider: CultureInfo.CurrentCulture,
                style: DateTimeStyles.None);
        }
    }

    public class VmGigValidator : AbstractValidator<ViewModelGig>
    {
        public VmGigValidator()
        {
            RuleFor(x => x.Venue)
                .NotEmpty()
                .WithMessage("Venue is required")
                .MaximumLength(40)
                .WithMessage("Venue name too long");

            RuleFor(x => x.Date)
                .Must(_ValidateDateFormat)
                .WithMessage("Invalid date format, it should be 'yyyy/MM/dd'!")
                .Must(_ValidateFutureDate)
                .WithMessage("Date must be in future");

            RuleFor(x => x.Time)
                .Must(_ValidateTimeFormat)
                .WithMessage("Invalid time format, must be in 'HH/mm AM|PM'!");

            RuleFor(x => x.GenreId)
                .NotEmpty()
                .WithMessage("Genre is required");
        }

        private bool _ValidateFutureDate(string value)
        {
            DateTime date;
            var isValidDate = DateTime.TryParseExact(
                s: Convert.ToString(value),
                format: "yyyy-MM-dd",
                provider: CultureInfo.CurrentCulture,
                style: DateTimeStyles.None,
                result: out date);

            if (isValidDate)
                return date > DateTime.Now;
            else
                return false;
        }

        private bool _ValidateDateFormat(string value)
        {
            DateTime date;
            return DateTime.TryParseExact(
                s: Convert.ToString(value),
                format: "yyyy-MM-dd",
                provider: CultureInfo.CurrentCulture,
                style: DateTimeStyles.None,
                result: out date);
        }

        private bool _ValidateTimeFormat(string value)
        {
            DateTime time;
            return DateTime.TryParseExact(
                s: Convert.ToString(value),
                format: "HH:mm",
                provider: CultureInfo.CurrentCulture,
                style: DateTimeStyles.None,
                result: out time);
        }
    }
}
