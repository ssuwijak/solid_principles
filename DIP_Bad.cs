namespace SOLID_Principles.DIP.Bad
{
	public class FileLogger
	{
		public void LogMessage(string aStackTrace)
		{
			//code to log stack trace into a file.  
		}
	}
	public class ExceptionLogger
	{
		public void LogIntoFile(Exception aException)
		{
			FileLogger objFileLogger = new FileLogger();
			objFileLogger.LogMessage(GetUserReadableMessage(aException));
		}
		private string GetUserReadableMessage(Exception ex)
		{
			string strMessage = string.Empty;
			//code to convert Exception's stack trace and message to user readable format.  
			//....
			//....

			return strMessage;
		}
	}
	public class DataExporter
	{
		public void ExportDataFromFile()
		{
			try
			{
				//code to export data from files to database.  
			}
			catch (Exception ex)
			{
				// *** bad smell
				new ExceptionLogger().LogIntoFile(ex); // <-- client wants to store this stack trace in a database if an IO exception occurs.
			}
		}
	}
	/// <summary>
	/// try to use DbLogger instead of ExceptionLogger and FileLogger
	/// but it is the same FileLogger, unless class name
	/// </summary>
	public class DbLogger
	{
		public void LogMessage(string aMessage)
		{
			//Code to write message in database.  
		}
	}

	public class ExceptionLogger_Avoid_FileLogger_Dependecy
	{
		public void LogIntoFile(Exception aException)
		{
			FileLogger objFileLogger = new FileLogger();
			objFileLogger.LogMessage(GetUserReadableMessage(aException));
		}
		public void LogIntoDataBase(Exception aException)
		{
			DbLogger objDbLogger = new DbLogger();
			objDbLogger.LogMessage(GetUserReadableMessage(aException));
		}
		private string GetUserReadableMessage(Exception ex)
		{
			string strMessage = string.Empty;
			//code to convert Exception's stack trace and message to user readable format.  
			//....
			//....

			return strMessage;
		}
	}
	public class DataExporter_Implement_DbLogger
	{
		public void ExportDataFromFile()
		{
			try
			{
				//code to export data from files to database.  
			}
			catch (IOException ex)
			{
				new ExceptionLogger_Avoid_FileLogger_Dependecy().LogIntoDataBase(ex);
			}
			catch (Exception ex)
			{
				new ExceptionLogger_Avoid_FileLogger_Dependecy().LogIntoFile(ex);
			}
		}
	}
}
