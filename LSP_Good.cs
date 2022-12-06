using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.LSP.Good
{
	public interface IReadableSqlFile
	{
		string LoadText();
	}
	public interface IWritableSqlFile
	{
		void SaveText();
	}

	public class ReadOnlySqlFile : IReadableSqlFile
	{
		public string FilePath { get; set; }
		public string FileText { get; set; }
		string IReadableSqlFile.LoadText()
		{
			throw new NotImplementedException();
		}
	}

	public class SqlFile : IWritableSqlFile, IReadableSqlFile
	{
		public string FilePath { get; set; }
		public string FileText { get; set; }
		string IReadableSqlFile.LoadText()
		{
			throw new NotImplementedException();
		}

		void IWritableSqlFile.SaveText()
		{
			throw new NotImplementedException();
		}
	}

	public class SqlFileManager
	{
		public string GetTextFromFiles(List<IReadableSqlFile> aLstReadableFiles)
		{
			StringBuilder objStrBuilder = new StringBuilder();
			foreach (var objFile in aLstReadableFiles)
			{
				objStrBuilder.Append(objFile.LoadText());
			}
			return objStrBuilder.ToString();
		}
		public void SaveTextIntoFiles(List<IWritableSqlFile> aLstWritableFiles)
		{
			foreach (var objFile in aLstWritableFiles)
			{
				objFile.SaveText();
			}
		}
	}
}
