using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace SOLID_Principles.SLR
{/// <summary>
 /// mockup class for User class
 /// </summary>
	public class User
	{
		public User(string email, string pwd)
		{

		}
	}
}

namespace SOLID_Principles.SLR.Bad
{
	public class UserService
	{
		public void Register(string email, string password)
		{
			if (!ValidateEmail(email))
				throw new ValidationException("Email is not an email");
			var user = new User(email, password);

			SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject = "HEllo foo" });
		}
		public virtual bool ValidateEmail(string email)
		{
			return email.Contains("@");
		}
		public void SendEmail(MailMessage message)
		{
			SmtpClient _smtpClient = new SmtpClient();

			_smtpClient.Send(message);
		}


	}


}
