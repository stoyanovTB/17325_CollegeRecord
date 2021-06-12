using System;

public class AcademicStaff : Staff
{
	private string academicTitle;

	public AcademicStaff()
	{

	}

	public AcademicStaff(int id, string academicTitle, string firstName, string lastName, string phoneNumber, string email, string jobTitle, string department, bool isFullTimeStaff) : base(id, firstName, lastName, phoneNumber, email, jobTitle, department, isFullTimeStaff)
	{
		this.academicTitle = academicTitle;
	}

	public override string ToString() {
		return $"\n\tID: {this.Id}\n\tName: {this.FirstName} {this.LastName}\n\tJob Title: {this.JobTitle}\n\tAcademic Title: {this.academicTitle}\n\tDepartment: {this.Department}\n\tContact Details:\n\t{this.PhoneNumber}\n\t{this.Email}\n\tFull-Time Staff: {this.IsFullTimeStaff}\n";
	}
}
