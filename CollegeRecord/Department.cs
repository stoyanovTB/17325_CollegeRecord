using System;

public class Department
{
	private int id;
	private string departmentName;

    public int Id { get => id; set => id = value; }
    public string DepartmentName { get => departmentName; set => departmentName = value; }

	public Department(int id, string departmentName)
	{
		this.Id = id;
		this.DepartmentName = departmentName;
	}

	public override string ToString()
	{
		return $"ID: {this.Id} Depratment Name: {this.DepartmentName}";
	}
}
