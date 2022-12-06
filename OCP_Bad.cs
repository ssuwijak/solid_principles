namespace SOLID_Principles.OCP.Bad
{
	public class Rectangle
	{
		public double Height { get; set; }
		public double Width { get; set; }
	}
	public class Circle
	{
		public double Radius { get; set; }
	}
	/// <summary>
	/// try to add a new class to add new features and avoid to modify the exist ones
	/// </summary>
	public class AreaCalculator
	{
		public double TotalArea(object[] arrObjects)
		{
			double area = 0;

			foreach (var obj in arrObjects)
			{
				if (obj is Rectangle)
				{
					Rectangle o = (Rectangle)obj;
					area += o.Height * o.Width;
				}
				else
				{
					Circle o = (Circle)obj;
					area += o.Radius * o.Radius * Math.PI;
				}
			}
			return area;
		}
	}
}
