namespace SOLID_Principles.ISP.Bad
{
	public interface ILead
	{
		void CreateSubTask();
		void AssginTask();
		void WorkOnTask();
	}
	public class TeamLead : ILead
	{
		void ILead.AssginTask()
		{
			//throw new NotImplementedException();
			//Code to assign a task
		}
		void ILead.CreateSubTask()
		{
			//throw new NotImplementedException();
			//Code to create a sub task 
		}
		void ILead.WorkOnTask()
		{
			//throw new NotImplementedException();
			//Code to implement perform assigned task. 
		}
	}
	public class Manager : ILead
	{
		void ILead.AssginTask()
		{
			//throw new NotImplementedException();
			//Code to assign a task
		}
		void ILead.CreateSubTask()
		{
			//throw new NotImplementedException();
			//Code to create a sub task 
		}
		void ILead.WorkOnTask()
		{
			// manage should not work by himself.
			throw new Exception("Manager can't work on Task");
		}
	}
}
