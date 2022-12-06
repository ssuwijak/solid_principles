using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SOLID_Principles.SLR
{
	/// <summary>
	/// mockup class for DbContext class
	/// lazy to import and using declaration
	/// </summary>
	public class DbContext
	{
		public void Save(User user) { }
	}
}
namespace SOLID_Principles.SLR.Good
{
	public class UserService
	{
		EmailService _emailService;
		DbContext _dbContext;
		public UserService(EmailService aEmailService, DbContext aDbContext)
		{
			_emailService = aEmailService;
			_dbContext = aDbContext;
		}
		public void Register(string email, string password)
		{
			if (!_emailService.ValidateEmail(email))
				throw new ValidationException("Email is not an email");
			var user = new User(email, password);
			_dbContext.Save(user);
			_emailService.SendEmail(new MailMessage("myname@mydomain.com", email) { Subject = "Hi. How are you!" });
		}
	}
	public class EmailService
	{
		SmtpClient _smtpClient;
		public EmailService(SmtpClient aSmtpClient)
		{
			_smtpClient = aSmtpClient;
		}
		/// <summary>
		/// virtual in C# = overridable in VB.NET
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public virtual bool ValidateEmail(string email)
		{
			return email.Contains("@");
		}
		public void SendEmail(MailMessage message)
		{
			_smtpClient.Send(message);
		}
	}
}
