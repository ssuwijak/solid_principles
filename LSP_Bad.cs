using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.LSP.Bad
{
	public class SqlFile
	{
		public string FilePath { get; set; }
		public string FileText { get; set; }
		public string LoadText()
		{
			/* Code to read text from sql file */
			return "";

		}
		public string SaveText()
		{
			/* Code to save text into sql file */
			return "";
		}
	}
	public class SqlFileManager
	{
		public List<SqlFile> lstSqlFiles { get; set; }

		public string GetTextFromFiles()
		{
			StringBuilder objStrBuilder = new StringBuilder();
			foreach (var objFile in lstSqlFiles)
			{
				objStrBuilder.Append(objFile.LoadText());
			}
			return objStrBuilder.ToString();
		}
		public void SaveTextIntoFiles()
		{
			foreach (var objFile in lstSqlFiles)
			{
				objFile.SaveText();
			}
		}
	}
	/// <summary>
	/// a few read-only files in the application folder, so we need to restrict the flow whenever it tries to do a save on them.
	/// </summary>
	public class ReadOnlySqlFile : SqlFile
	{
		public string FilePath { get; set; }
		public string FileText { get; set; }
		public string LoadText()
		{
			/* Code to read text from sql file */
			return "";

		}
		public void SaveText()
		{
			/* Throw an exception when app flow tries to do save. */
			throw new IOException("Can't Save");
		}
	}

	public class SqlFileManager_AvoidExeception
	{
		public List<SqlFile> lstSqlFiles { get; set; }
		public string GetTextFromFiles()
		{
			StringBuilder objStrBuilder = new StringBuilder();
			foreach (var objFile in lstSqlFiles)
			{
				objStrBuilder.Append(objFile.LoadText());
			}
			return objStrBuilder.ToString();
		}
		public void SaveTextIntoFiles()
		{
			foreach (var objFile in lstSqlFiles)
			{
				//Check whether the current file object is read-only or not.If yes, skip calling it's  
				// SaveText() method to skip the exception.  

				if (objFile is not ReadOnlySqlFile)
					objFile.SaveText();
			}
		}
	}
}
