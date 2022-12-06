namespace SOLID_Principles.DIP.Good
{
	public interface ILogger
	{
		void LogMessage(string aString);
	}
	public class DbLogger : ILogger
	{
		public void LogMessage(string aMessage)
		{
			//Code to write message in database.  
		}
	}
	public class FileLogger : ILogger
	{
		public void LogMessage(string aStackTrace)
		{
			//code to log stack trace into a file.  
		}
	}
	public class ExceptionLogger
	{
		private ILogger _logger;
		public ExceptionLogger(ILogger aLogger)
		{
			this._logger = aLogger;
		}
		public void LogException(Exception aException)
		{
			string strMessage = GetUserReadableMessage(aException);
			this._logger.LogMessage(strMessage);
		}
		private string GetUserReadableMessage(Exception aException)
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
			ExceptionLogger _exceptionLogger;
			try
			{
				//code to export data from files to database.  
			}
			catch (IOException ex)
			{
				_exceptionLogger = new ExceptionLogger(new DbLogger());
				_exceptionLogger.LogException(ex);
			}
			catch (Exception ex)
			{
				_exceptionLogger = new ExceptionLogger(new FileLogger());
				_exceptionLogger.LogException(ex);
			}
		}
	}
	/// <summary>
	/// if there is a new error/exception
	/// just add a new exception block without 
	/// any change in ExceptionLogger class
	/// </summary>
	public class EventLogger : ILogger
	{
		public void LogMessage(string aMessage)
		{
			//Code to write message in system's event viewer.  
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public class DataExporter_AddNewException_But_NoChangeExceptionLogger
	{
		public void ExportDataFromFile()
		{
			ExceptionLogger _exceptionLogger;
			try
			{
				//code to export data from files to database.  
			}
			catch (IOException ex)
			{
				_exceptionLogger = new ExceptionLogger(new DbLogger());
				_exceptionLogger.LogException(ex);
			}
			catch (SqlException ex)
			{
				// just add exception block to the new type of error handler, no change in ExceptionLogger anymore
				_exceptionLogger = new ExceptionLogger(new EventLogger());
				_exceptionLogger.LogException(ex);
			}
			catch (Exception ex)
			{
				_exceptionLogger = new ExceptionLogger(new FileLogger());
				_exceptionLogger.LogException(ex);
			}
		}
	}
	/// <summary>
	/// mockup class for SqlException class
	/// lazy to import and declare using directive
	/// </summary>
	public class SqlException : Exception { }
}
